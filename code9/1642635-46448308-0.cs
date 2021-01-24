    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IDictionary<string, object> Properties { get; set; }
    }
