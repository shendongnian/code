    public class BabysFirstsUsersDataEntities
    {
        public BabysFirstsUsersDataEntities() { this.UserImageLists = new List<UserImageList>(); }
        public List<UserImageList> UserImageLists { get; set; }
    }
    public class UserImageList
    {
        public string email { get; set; }
        public List<string> urlList;
    }
