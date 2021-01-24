    public int Create()
        {
        	Person person = new Person();
        	person.name = 'Bert';
        
        	using (PersonSportEntities db = new PersonSportEntities())
        	{	
        		Sport sport = db.Sport.Find(1);
        		person.Sport = sport;
        	
        		db.Person.Add(person);
        		db.SaveChanges();
        	}
        }
