    public class Service : IService
    {
        public UserRights GetUserRights()
        {
            UserRights userRights = new UserRights();
            //Set other properties.
            return userRights;
        }
    }
    public class UserRights
    {
        public static bool _canEdit;
    }
