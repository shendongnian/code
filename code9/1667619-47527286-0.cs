    public Employee CreatePartnerWithUser(Employee employee, List<Language> language)
    {
    	using (DataContext context = new DataContext())
    	{
    		using (var trans = context.Database.BeginTransaction())
    		{
    			var insertEmployee = context.Employee.Add(employee);
                context.SaveChanges();
    						
    			var insertLanguage = context.Language.AddRange(language);
    			context.SaveChanges();
    
    			trans.Commit();
    		}
    	}
    }
