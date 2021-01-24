    public class Department{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get { return DateTime.Now; } private set { }
    }
