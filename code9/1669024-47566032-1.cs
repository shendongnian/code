    public class Booking
    {
    	public int BookingIDNum { get; set; }
    	public int BookTypeNum { get; set; }
    	public int FacIDNum { get; set; }
    }
    
    public class BookingType
    {
    	public int BookTypeNum { get; set; }
    	public string BookType { get; set; }
    }
    
    public class Facility
    {
    	public int FacIDNum { get; set; }
    	public string FacilityName { get; set; }
    }
    
    public class ViewData
    {
    	public int BookingIDNum { get; set; }
    	public int BookTypeNum { get; set; }
    	public string BookType { get; set; }
    	public int FacIDNum { get; set; }
    	public string FacilityName { get; set; }
        public static ViewData From(Booking booking, BookingType bookingType, Facility facility)
        {
    	    return new ViewData
    	    {
    		    BookingIDNum = booking.BookingIDNum,
    		    BookingTypeNum = booking.BookingTypeNum,
    		    FacIDNum = booking.FacIDNum,
    		    BookType = bookingType.BookType,
    		    FacilityName = facility.FacilityName
    	    };
        }
    }
