    public class User
    {
        public User()
        {
        }
        public int UserId { get; set; }
        public int UserDefaultModelId { get; set; }
        public virtual UserDefaultModel UserDefaultModel { get; set; }
    }
    public class UserDefaultModel
    {
        public UserDefaultModel()
        {
            Users = new List<User>();
        }
        public int UserDefaultModelId { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
