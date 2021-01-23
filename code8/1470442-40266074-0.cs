    public class RentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    
        public DbSet<Rent> Rents { get; set; }
    
        public DbSet<Car> Cars { get; set; }
    }
    
    public class Car
    {
        public int Id { get; set; }
    
        public string Model { get; set; }
    
        public double Price { get; set; }
    }
    
    public class Rent
    {
        public int Id { get; set; }
    
        public Student Student { get; set; }
    
        public Car Car { get; set; }
    }
    
    public class Student
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public int Year { get; set; }
    }
