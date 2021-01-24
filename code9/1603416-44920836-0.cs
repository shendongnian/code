    public enum BookingDetails
        {
            BOOKED = 1, EXECUTING = 2, EXECUTED = 3, SUSPENDED = 4, CANCELLED = 5
        }
    
        public class SomeModel
        {
            public BookingDetails bookingDetails { get; set; }
    
            public static IEnumerable<SelectListItem> GetBookingDetailsSelectItems()
            {
                yield return new SelectListItem { Text = "BOOKED", Value = "1" };
                yield return new SelectListItem { Text = "EXECUTING", Value = "2" };
                yield return new SelectListItem { Text = "EXECUTED", Value = "3" };
                yield return new SelectListItem { Text = "SUSPENDED", Value = "4" };
                yield return new SelectListItem { Text = "CANCELLED", Value = "5" };
            }
        }
