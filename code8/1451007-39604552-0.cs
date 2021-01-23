    [Table("Person")]
    public abstract class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
    [Table("User")]
    public class User : Person
    {
        public string Name { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
    }
