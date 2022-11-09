namespace BookingSystem
{
    public class CheckStatusReq
    {
        public string BookingCode { get; set; }

        public CheckStatusReq(string bookingCode)
        {
            BookingCode = bookingCode;
        }
    }
}
