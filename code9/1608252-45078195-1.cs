    public int Create()
        {
        	Person person = new Person();
        	person.name = 'Bert';
        
        	using (PersonSportEntities db = new PersonSportEntities())
        	{	
        		List<Sport> sport = db.Sport.Where(x => x.ID = 1).ToList();
        		person.Sport = sport;
        	
        		db.Person.Add(person);
        		db.SaveChanges();
        	}
        }
