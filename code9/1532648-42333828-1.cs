    public class Dog
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }            
    using (IDbConnection conn = OpenConnection())
    {
        var dog = conn
            .Query<Dog>("Select * from Dog where Age = @Age", new { Age = 10 })
            .FirstOrDefault();
    }
