    public class Booking{
    
        string Name;
        string Surname;
        string PESEL; //your key? remember to manage duplicates if you insert manually (better if it were generated automatically as unique data (Guid))
        string Room;
    }
    
    System.Collections.Generic.List<Booking> bookings; //instantiate in Form constructor method
