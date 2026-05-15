namespace BookingTransactionScript.Core._3_Domain_Model
{
    internal class BookingCollection
    {
        private readonly IEnumerable<Booking> _bookings;

        public BookingCollection(IEnumerable<Booking> bookings)
        {
            _bookings = bookings;
        }

        public bool IsOverlapping(BookingPeriod bookingPeriod)
        {
            bool Overlapping(Booking b) => b.IsActive && bookingPeriod.IsOverlapping(b);
            return _bookings.Any(Overlapping);

            /*
            foreach (var booking in _bookings)
            {
                var overlaps = !booking.IsCancelled && bookingPeriod.IsOverlapping(booking);

                if (overlaps)
                {
                    return true;
                }
            }

            return false;
            */
        }
    }
}
