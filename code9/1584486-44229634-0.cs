    public class User : BaseObject
    { //... your code here
        [Association("User-UserUnits")]
        public XPCollection<UserUnit> UserUnits
        {
            get
            {
                return GetCollection<UserUnit>("UserUnits");
            }
        }
    }
    
    public class Unit : BaseObject
    { // ... your code here
        [Association("Unit-UserUnits")]
        public XPCollection<UserUnit> UsersUnitss
        {
            get
            {
                return GetCollection<UserUnit>("UserUnits");
            }
        }
    }
    public class UserUnit : BaseObject
    { 
        User user;
        [Association("User-UserUnits")]
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                SetPropertyValue("User", ref user, value);
            }
        }
        Unit unit;
        [Association("Unit-UserUnits")]
        public Unit Unit
        {
            get
            {
                return unit;
            }
            set
            {
                SetPropertyValue("Unit", ref unit, value);
            }
        }
        int status;
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                SetPropertyValue("Status", ref status, value);
            }
        }
    }
