using BookingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IMemoryCache _memoryCache;

        public SearchController(ISearchService searchService, IMemoryCache memoryCache)
        {
            _searchService = searchService;
            _memoryCache = memoryCache;
        }

        [HttpGet("{destination}")]
        public async Task<SearchRes> Get(string destination)
        {
            var request = new SearchReq(destination, DateTime.Now, DateTime.Now.AddDays(new Random().NextDouble()*10));
            _memoryCache.Set("SearchRequest",request);
            var response = await _searchService.GetHotels(request);
            _memoryCache.Set("SearchResponse", response);
            return response;
        }

        [HttpGet("{destination}/{departureAirport}")]
        public async Task<SearchRes> Get(string destination, string departureAirport)
        {

            var request = new SearchReq(destination, departureAirport, DateTime.Now, DateTime.Now.AddDays(new Random().NextDouble() * 10));
            _memoryCache.Set("SearchRequest", request);
            var response = await _searchService.GetHotelsAndFlights(request);
            _memoryCache.Set("SearchResponse", response);
            return response;
        }

    }
}
