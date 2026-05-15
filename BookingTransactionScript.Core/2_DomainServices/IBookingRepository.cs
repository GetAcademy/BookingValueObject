using BookingTransactionScript.Core._3_Domain_Model;

namespace BookingTransactionScript.Core._2_DomainServices
{
    public interface IBookingRepository
    {
        Task<Booking?> GetAsync(Guid bookingId);
        Task<List<Booking>> GetAllAsync();
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
    }
}
