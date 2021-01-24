	public IQueryable<SomeEntity> Get() {
		return dbContext.SomeEntities
			.Where(x => optionalPreFiltereExpression)
			.Select(x => new SomeDTO(){
				Prop1 = x.Prop1,
				Collection1 = x.CollectionOfInterest,
				// etc
			});
	}
	
