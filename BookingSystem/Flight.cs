namespace BookingSystem
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string FlightCode { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

        public Flight(string flightNumber, string flightCode, string departureAirport, string arrivalAirport)
        {
            FlightNumber = flightNumber;
            FlightCode = flightCode;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
        }
    }
}
