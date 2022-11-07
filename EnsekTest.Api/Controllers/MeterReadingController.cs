using EnsekTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace EnsekTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadingController : ControllerBase
    {

        private readonly IMeterReadingService _service;
        private readonly ILogger<MeterReadingController> _logger;

        public MeterReadingController(ILogger<MeterReadingController> logger, IMeterReadingService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("meter-reading-uploads")]
        public async Task<string> Upload([FromForm]IFormFile file)
        {
            if(file.Length <= 0)
            {
                return "Something went wrong";
            }
            var tempDirectory = @"c:\temp";
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(tempDirectory, fileName);
            Directory.CreateDirectory(tempDirectory);
            try
            {
                using (var stream = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch(Exception ex)
            {
                var error = ex.Message;
            }

            return await _service.ProcessFile(path);
        }
    }
}