    public class Person
    {
       public int PersonId { get; set; }
       public string Name { get; set; }
       public string Email { get; set; }
       public string Mobile { get; set; }
       public PersonType Person { get; set; }
    }
    enum PersonType
    {
       Student,
       Parent
    }
