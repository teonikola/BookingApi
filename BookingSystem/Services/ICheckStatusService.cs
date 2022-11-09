using Microsoft.Extensions.Caching.Memory;

namespace BookingSystem.Services
{
    public interface ICheckStatusService
    {
        public string GetStatus(string bookingCode, IMemoryCache memoryCache);    
    }
}
