    public class Person
    {
      public int PersonId { get; set; }
      public string Name { get; set; }
    }
    public class Car
    {
      public int CarId { get; set; }
      public string LicensePlate { get; set; }
    }
    public class MyDemoContext : DbContext
    {
      public DbSet<Person> People { get; set; }
      public DbSet<Car> Cars { get; set; }
    }
