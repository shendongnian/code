    public class Customer
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public virtual List<Booking> Bookings { get; set; }
    }
    public class Booking
    {
    	public int Id { get; set; }
    	public string Title{ get; set; }
    	public DateTime BookingDate { get; set; }
    	public int CustomerId { get; set; }
    	public virtual Customer Customer { get; set; }
    }
