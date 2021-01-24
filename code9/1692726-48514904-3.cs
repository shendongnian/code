    public class Service : IService
    {
        public UserRights GetUserRights()
        {
            UserRights userRights = new UserRights();
            //Set other properties.
            return userRights;
        }
    }
    [DataContract]
    public class UserRights
    {
        [DataMember]
        public static bool _canEdit;
    }
