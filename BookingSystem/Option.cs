namespace BookingSystem
{
    public class Option
    {
        public int OptionCode { get; set; }
        public string HotelCode { get; set; }
        public string FlightCode { get; set; }
        public string ArrivalAirport { get; set; }
        public double Price { get; set; }

        public Option(int optionCode, string hotelCode, string flightCode, string arrivalAirport, double price)
        {
            OptionCode = optionCode;
            HotelCode = hotelCode;
            FlightCode = flightCode;
            ArrivalAirport = arrivalAirport;
            Price = price;
        }
    }
}
