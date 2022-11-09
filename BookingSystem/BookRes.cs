namespace BookingSystem
{
    public class BookRes
    {
        public string BookingCode { get; set; }
        public DateTime BookingTime { get; set; }

        public int sleepTime { get; set; }

        public BookRes(string bookingCode, DateTime bookingTime, int sleepTime)
        {
            BookingCode = bookingCode;
            BookingTime = bookingTime;
            this.sleepTime = sleepTime;
        }
    }
}
