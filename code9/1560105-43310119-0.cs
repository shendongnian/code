    public interface IUser
    {
        string GetName();
    }
    
    public class Guest : IUser
    {
        private readonly string _guestName;
    
        public Guest(string guestName)
        {
            _guestName = guestName;
        }
    
        public string GetName()
        {
            return _guestName;
        }
    }
    
    public class Admin : IUser
    {
        private readonly string _adminName;
    
        public Guest(string adminName)
        {
            _adminName = adminName;
        }
    
        public string GetName()
        {
            return _adminName;
        }
    }
