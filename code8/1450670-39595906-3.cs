    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
    }
    public class UserEducation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PassingYear { get; set; }
        public string Education { get; set; }
    }
