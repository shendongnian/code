    public class PropertyManager : IDisposable, IPropertyManager
        {
            private readonly IPropertyRepo _propertyRepo;
           
    
            // Used from Controller or Unit Testing
            public PropertyManager(IPropertyRepo propertyRepo)
            {
                if (propertyRepo == null)
                    throw new ArgumentNullException("propertyRepo");
                this._propertyRepo = propertyRepo;
            }
        }
    public class UserManager : IDisposable, IUserManager
        {
            private readonly IUserRepo _userRepo;
            
    
            // Used from Controller or Unit Testing
            public UserManager(IUserRepo userRepo)
            {
                if (userRepo == null)
                    throw new ArgumentNullException("userRepo");
                this._userRepo = userRepo;
            }
        }
