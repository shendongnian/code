    public class Adress
    {
       public Person Person { get; set; }
       public int PersonId {get; set;}   
    }
    var adress = new Adress()
    {                   
        Person = person
    };
    Db.Adresses.Add(adress);
    Db.SaveChanges();
