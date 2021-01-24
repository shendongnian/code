    public class PersonSport
    {
       public int Id {get; set;} //key and auto increment
       public int PersonId {get; set}
       public int SportId {get; set}
    
    // relationship
       public virtual List<Person> Persons {get; set;} 
       public virtual List<Sport> Sports {get; set;} 
    }
    public int Create()
        {
            var personSport=new PersonSport();
            personSport.SportId=1; 
            personSport.Person=new Person()
            {
             Name="Bert"
            };
            using (PersonSportEntities db = new PersonSportEntities())
            {   
                db.PersonSport.Add(personSport);
                db.SaveChanges();
            }
        }
