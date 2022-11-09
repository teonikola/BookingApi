using BookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckStatusController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICheckStatusService _checkStatusService;

        public CheckStatusController(ICheckStatusService checkStatusService , IMemoryCache memoryCache)
        {
            _checkStatusService = checkStatusService;
            _memoryCache = memoryCache;
           
        }

        [HttpGet(Name = "CheckStatus")]
        public string CheckStatus(string bookingCode)
        {
            return _checkStatusService.GetStatus(bookingCode,_memoryCache);
        }
    }
}
