namespace BookingSystem
{
    public class SearchReq
    {
        public string Destination { get; set; }

        public string? DepartureAirport { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public SearchReq(string destination, string? departureAirport, DateTime fromDate, DateTime toDate)
        {
            Destination = destination;
            DepartureAirport = departureAirport;
            FromDate = fromDate;
            ToDate = toDate;
        }

        public SearchReq(string destination, DateTime fromDate, DateTime toDate)
        {
            Destination = destination;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }

   
}
