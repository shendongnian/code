    public class Dog
    {
        public int? Age { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }
        public int IgnoredProperty { get { return 1; } }
    }            
    var guid = Guid.NewGuid();
    var dog = connection.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });
