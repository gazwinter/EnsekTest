using EnsekTest.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTest.Services.Interfaces
{
    public interface IMeterReadingService
    {
        
        Task<string> ProcessFile(string path);
        bool ValidateAccountId(int accountIdToValidate, out int accountId);
        bool ValidateDate(string? dateTime, out DateTime readDate);
        bool ValidateMeterReading(string? readingValue, int accountId, out int value);
    }
}
