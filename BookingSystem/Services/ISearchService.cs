namespace BookingSystem.Services
{
    public interface ISearchService
    {
        public  Task<SearchRes> GetHotels(SearchReq searchReq);

        public Task<SearchRes> GetHotelsAndFlights(SearchReq searchReq);
    }
}
