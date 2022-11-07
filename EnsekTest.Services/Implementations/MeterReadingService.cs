using CsvHelper;
using CsvHelper.Configuration;
using EnsekTest.Data;
using EnsekTest.Data.Entities;
using EnsekTest.Services.Interfaces;
using EnsekTest.Services.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Text.Json.Nodes;

namespace EnsekTest.Services.Implementations
{
    public class MeterReadingService : IMeterReadingService
    {
        private EnsekTestContext _context;
        public MeterReadingService(EnsekTestContext context)
        {
            _context = context;
        }
        
        public async Task<string> ProcessFile(string path)
        {
            var result = new ReadingResults();
            var meterReadings = new List<MeterReadings>();

            using(var reader = new StreamReader(path))
            {
                var config = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };
                using(var csv = new CsvReader(reader, config))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        if (csv.Parser.Record == null || csv.Parser.Record.Length != 3)
                        {
                            //Too many fields invalidate immediately
                            result.FailedReadings += 1;
                        }
                        else
                        {
                            
                            int accountId;
                            DateTime meterReadDate;
                            int meterReadValue;
                            //Validate each field
                            if (ValidateAccountId(csv.GetField<int>("AccountId"), out accountId) && 
                                ValidateDate(csv.GetField("MeterReadingDateTime"), out meterReadDate) && 
                                ValidateMeterReading(csv.GetField("MeterReadValue"), csv.GetField<int>("AccountId"), out meterReadValue)) {
                                var record = new MeterReadings
                                {
                                    AccountId = accountId,
                                    MeterReadingDateTime = meterReadDate,
                                    MeterReadValue = meterReadValue
                                };

                                meterReadings.Add(record);
                                result.SuccessfullReadings += 1;
                            }
                            else
                            {
                                //Something wasn't right so we will fail the reading
                                result.FailedReadings += 1;
                            }
                            
                        }
                       
                    }

                   
                }
            }

            try
            {
                await _context.MeterReadings.AddRangeAsync(meterReadings);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Handle the exception somehow.
            }
            return JsonConvert.SerializeObject(result);
        }

        public bool ValidateMeterReading(string? readingValue, int accountId, out int value)
        {
            //Value needs to be an int
            if (int.TryParse(readingValue, out int reading))
            {
                var previousReading = _context.MeterReadings.OrderByDescending(m => m.MeterReadValue).FirstOrDefault(x => x.AccountId == accountId);
                //Value needs to be between 0 and 99999 and greater than this customers last reading
                if (reading > 0 && reading <= 99999 && (previousReading == null || reading > previousReading.MeterReadValue))
                {
                    value = reading;
                    return true;
                }
            }

            value = -1;
            return false;
        }

        public bool ValidateDate(string? dateTime, out DateTime readDate)
        {
            //First check if its a valid date, and then check if its in the past
            if(DateTime.TryParse(dateTime, out readDate))
            {
                return readDate < DateTime.Now;
            }

            return false;
        }

        public bool ValidateAccountId(int accountIdToValidate, out int accountId)
        {
            var account = _context.Accounts.FirstOrDefault(account => account.AccountId == accountIdToValidate);

            if(account == null)
            {
                accountId = -1;
                return false;
            }
            else
            {
                //Account is valid
                accountId = accountIdToValidate;
            }

            return true;
        }
    }
}
