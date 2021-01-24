    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set;}            
        public virtual List<User> GroupMembers { get; set; } = new List<User>();
    }
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public virtual List<Group> MemberOf {get; set;} = new List<Group>();
    }
