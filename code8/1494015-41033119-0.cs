    public class College
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public ICollection<User> Users { get; set; }
    }
    
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public College College{ get; set; }
    }
