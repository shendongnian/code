	public IList<MyCustomClass> FindResults(FooBarTask st)
	{
		var typeConstructor = typeof(MyCustomClass).GetConstructors()[0];
		return DataAccess.Find<MyCustomClass>(DetachedCriteria.For<FooBarResult>()
			.Add(Restrictions.Eq("Task", st))
            .SetProjection(
                Projections.ProjectionList()
                    .Add(Projections.Property("FieldOne"), "FieldOne")
                    .Add(Projections.Property("FieldTwo"), "FieldTwo")        
            )
            .SetResultTransformer(Transformers.AliasToBean(typeof(MyCustomClass)))
            .List<MyCustomClass>()
	}
