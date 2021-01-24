    public class PersonSport
    {
       public int Id {get; set;} //key and auto increment
       public int PersonId {get; set} //foreign key
       public int SportId {get; set} // foreign key
    
    // relationship
       public virtual Person Person {get; set;} 
       public virtual Sport Sport {get; set;} 
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
