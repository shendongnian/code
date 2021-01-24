    public class Person {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //etc..
        public string ApplicationUserId { get; set; }
    }
    public class MyContext :DbContext {
       public DbSet<Comment> Comments { get; set; }
       public DbSet<Person> Persons { get; set; }
       //... other DbSets
    }
    public class Comment{
       public int Id {get;set;}
       public string Message{get;set;}
       public DateTime Time{get;set;}
       public virtual Person Author {get;set;}
    }
