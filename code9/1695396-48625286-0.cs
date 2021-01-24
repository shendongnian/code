    public partial class UserMobileDevice
    {
        public User UiUser
        {
            get { return User; }
            set
            {
                User = value;
                if (value != null)
                    UserId = value.UserId;
            }
        }
    }
