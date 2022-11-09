using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BookingSystem.Services
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;

        public SearchService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<SearchRes> GetHotels(SearchReq searchReq)
        {
            var httpResponseMessage = await _httpClient.GetAsync("https://tripx-test-functions.azurewebsites.net/api/SearchHotels?destinationCode=" + searchReq.Destination);
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var hotels = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(content);
            var options = new List<Option>();

            if(hotels != null)
            {
                for (int i = 0; i < hotels.Count(); i++)
                {
                    var option = new Option(i, hotels.ElementAt(i).HotelCode, "", hotels.ElementAt(i).DestinationCode, i + 10);
                    options.Add(option);
                }
            }
       
            return new SearchRes(options.ToArray());
        }

        public async Task<SearchRes> GetHotelsAndFlights(SearchReq searchReq)
        {
            var httpResponseMessage = await _httpClient.GetAsync("https://tripx-test-functions.azurewebsites.net/api/SearchHotels?destinationCode=" + searchReq.Destination);
            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            var hotels = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(content);

            httpResponseMessage = await _httpClient.GetAsync(String.Format("https://tripx-test-functions.azurewebsites.net/api/SearchFlights?departureAirport={0}&arrivalAirport={1}",searchReq.DepartureAirport,searchReq.Destination));
            content = await httpResponseMessage.Content.ReadAsStringAsync();

            var flights = JsonConvert.DeserializeObject<IEnumerable<Flight>>(content);
            var options = new List<Option>();

            if (hotels !=null && flights!=null){
                for (int i = 0; i < hotels.Count(); i++)
                {
                    var flightsInDestCity = flights.Where(f => f.ArrivalAirport == hotels.ElementAt(i).DestinationCode);
                    for(int j = 0; j < flightsInDestCity.Count(); j++)
                    {
                        var option = new Option((i+j),hotels.ElementAt(i).HotelCode, flightsInDestCity.ElementAt(j).FlightCode, flightsInDestCity.ElementAt(j).ArrivalAirport, i+j+10);
                        options.Add(option);
                    }
            
                }
            }
            

            return new SearchRes(options.ToArray()); ;
        }
    }
}
