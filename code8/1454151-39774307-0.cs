    public IQueryOver<Person> GetQuery(ISession session)
    {
    	Person person = null;
    
    	DateTime? endDate = DateTime.Today;
    
    	SomePersonView dto = null;
    
    	IProjection birthDate = Projections.Conditional(
    		Restrictions.IsNull(Projections.Property(() => person.BirthDate)),
    		Projections.Constant(endDate, NHibernateUtil.DateTime),
    		Projections.Property(() => person.BirthDate));
    
    	var personQuery = session.QueryOver<Person>(() => person)
    		.Select(
    			Projections.Distinct(
    				Projections.ProjectionList()
    					.Add(Projections.SqlFunction("concat",
    							NHibernateUtil.String,
    							Projections.Property(() => person.FirstName),
    							Projections.Constant(" "),
    							Projections.Property(() => person.LastName)).WithAlias(() => dto.Name))
    					 .Add(Projections.Property(() => person.BirthDate).WithAlias(() => dto.BirthDate))
    					 .Add(DateProjections.Age("yy", birthDate, endDate).WithAlias(() => dto.Age))))
    		.TransformUsing(Transformers.AliasToBean<SomePersonView>());
    
    	return personQuery;
    }
