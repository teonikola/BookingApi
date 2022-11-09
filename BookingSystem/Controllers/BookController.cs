using BookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookingService bookingService, IMemoryCache memoryCache, ILogger<BookController> logger)
        {
            _bookingService = bookingService;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        [HttpPost(Name = "BookHotel")]
        public void Book(int optionCode)
        {
            SearchReq searchReq = (SearchReq)_memoryCache.Get("SearchRequest");

            SearchRes searchRes = (SearchRes)_memoryCache.Get("SearchResponse");
            if (searchRes == null)
                throw new ApplicationException("No results");
            var request = new BookReq(optionCode, searchReq);

            _bookingService.BookHotel(request, _memoryCache);   
        }
    }
}
