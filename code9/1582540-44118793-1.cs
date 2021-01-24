    static void Main(string[] args)
    {
      //This could be an add in a repo
      using (var context = new TesterEntities())
      {
    	context.tdCountry.Add(new tdCountry { CountryName = "Canada" });
    	context.SaveChanges();
      }
    
      //This could be an update in a repo
      using (var context = new TesterEntities())
      {
    	var getNewCountry = context.tdCountry.SingleOrDefault(x => x.CountryName == "Canada");
    	var people = context.tePerson.ToList();
    	getNewCountry.tePerson = people;
    	context.SaveChanges();
      }
    }
