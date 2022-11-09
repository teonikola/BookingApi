using Microsoft.Extensions.Caching.Memory;

namespace BookingSystem.Services
{
    public class CheckStatusService: ICheckStatusService
    {
       
        public string GetStatus(string bookingCode, IMemoryCache memoryCache)
        {

            if (memoryCache.Get("Bookings") != null)
            {
                List<BookRes> bookings = (List<BookRes>)memoryCache.Get("Bookings");

                var selectedBooking = bookings.Where(x => x.BookingCode.Equals(bookingCode)).FirstOrDefault();

                if (selectedBooking != null)
                {
                    if (DateTime.Now > selectedBooking.BookingTime.AddSeconds(selectedBooking.sleepTime))
                        return BookingStatusEnum.Success.ToString();
                    return BookingStatusEnum.Pending.ToString();
                }
            }

            return BookingStatusEnum.Failed.ToString();
        }
    }   

}
