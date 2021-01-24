    public class AttendeesController : ApiController
    {
        Attendee[] attendees = new Attendee[] 
        { 
            new Attendee { Id = 1, Name = "Mike" }, 
            new Attendee { Id = 2, Name = "Steve" }, 
            new Attendee{ Id = 3, Name = "Diane" } 
        };
        public IEnumerable<Attendee> GetAllAttendees()
        {
            // This is using a premade list of Attendees 
            // but you would get them here and return them
            
            // Will convert to JSON automatically
            return attendees;
        }
    }
