    public class EditBookingViewModel {
    
        // post as hidden field so we can fetch the record to update
        public long BookingId {get; set;} 
    
        // render inputs for these fields so they can be edited
        public DateTime ActualCheckIn  {get; set;}
        public DateTime ActualCheckOut {get; set;}
    }
