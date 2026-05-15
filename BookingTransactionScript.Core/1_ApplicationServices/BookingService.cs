using BookingTransactionScript.Core._2_DomainServices;
using BookingTransactionScript.Core._3_Domain_Model;
using BookingValueObject.Core._3_Domain_Model;

namespace BookingTransactionScript.Core._1_ApplicationServices
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly OpeningHours _openingHours = new(8, 16);

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Result<Booking>> BookAsync(DateTime start, DateTime end)
        {
            var validationResult = await ValidateBooking(start, end);
            if (!validationResult.IsSuccess) return validationResult;

            var newBooking = new Booking(start, end);
            await _bookingRepository.AddAsync(newBooking);
            return Result<Booking>.Success(newBooking);
        }

        public async Task<Result<Booking>> CancelAsync(Guid bookingId, DateTime start, DateTime end)
        {
            // validering - kun for å optimalisere ytelse, ikke nødvendig for korrekthet
            var result = ValidateBookingPeriod(start, end);
            if (!result.IsSuccess) return Result<Booking>.Fail("Ugyldig start og end - sjekket ikke db");

            var booking = await _bookingRepository.GetAsync(bookingId);
            if (booking == null) return Result<Booking>.Fail("Bookingen eksisterer ikke");
            booking.Cancel();
            _bookingRepository.UpdateAsync(booking);
            return Result<Booking>.Success(booking);
        }

        private async Task<Result<Booking>> ValidateBooking(DateTime start, DateTime end)
        {
            var result = ValidateBookingPeriod(start, end);
            if (!result.IsSuccess) return Result<Booking>.Fail(result.ErrorMessage);
            var bookingPeriod = result.Value!;
            var existingBookings = await _bookingRepository.GetAllAsync();
            var existingBookingCollection = new BookingCollection(existingBookings);
            if (existingBookingCollection.IsOverlapping(bookingPeriod))
            {
                return Result<Booking>.Fail("Booking overlaps with an existing booking.");
            }

            return Result<Booking>.Success(null);
        }

        private Result<BookingPeriod> ValidateBookingPeriod(DateTime start, DateTime end)
        {
            var bookingPeriodResult = BookingPeriod.Create(start, end);
            if (!bookingPeriodResult.IsSuccess)
            {
                return Result<BookingPeriod>.Fail(bookingPeriodResult.ErrorMessage!);
            }

            var period = bookingPeriodResult.Value;
            if (!period.IsWithin(_openingHours))
            {
                return Result<BookingPeriod>.Fail("Booking must be within opening hours.");
            }

            return Result<BookingPeriod>.Success(period);
        }
    }
}
