    public class Adress
    {
       public Person Person { get; set; }
       public int PersonId {get; set;}   
    }
    var adress = new Adress()
    {                   
        PersonID = person.PersonID,
    };
