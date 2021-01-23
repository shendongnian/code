    public class UserEntity
    {
        string _username;
        public string Username
        {
            get { return _username; }
        }
    
        bool _isAdministrator;
        public bool IsAdministrator
        {
            get { return _isAdministrator; }
        }
    
        public UserEntity(Administrator entity)
        {
            _isAdministrator = true;
            _username = entity.AID;
        }
    
        public UserEntity(Teacher entity)
        {
            _isAdministrator = false;
            _username = entity.TID;
        }
    
        public static explicit operator UserEntity(Administrator entity)
        {
            return new UserEntity(entity);
        }
    
        public static explicit operator UserEntity(Teacher entity)
        {
            return new UserEntity(entity);
        }
    }
