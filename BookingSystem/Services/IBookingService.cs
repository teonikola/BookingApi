using Microsoft.Extensions.Caching.Memory;

namespace BookingSystem.Services
{
    public interface IBookingService
    {
        public BookRes BookHotel(BookReq bookReq, IMemoryCache memoryCache);
    }
}
