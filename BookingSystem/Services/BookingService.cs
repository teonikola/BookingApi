using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace BookingSystem.Services
{
    public class BookingService: IBookingService
    {
        public BookRes BookHotel(BookReq bookReq, IMemoryCache memoryCache)
        {           
            string bookingCode = "abc12"+ bookReq.OptionCode.ToString();
            int sleepTime = new Random().Next(45, 60);
            DateTime bookingTime = DateTime.Now;
            var bookRes = new BookRes(bookingCode, bookingTime, sleepTime);

            if (memoryCache.Get("Bookings") != null)
            {
                List<BookRes> bookings = (List<BookRes>)memoryCache.Get("Bookings");
                bookings.Add(bookRes);
                memoryCache.Set("Bookings", bookings);
            }
            else
            {
                List<BookRes> bookings = new List<BookRes> {bookRes};
                memoryCache.Set("Bookings", bookings);
            }
            return bookRes;
        }
    }
}
