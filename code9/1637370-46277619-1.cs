	public IQueryable<SomeEntity> Get() {
		return new List<SomeDTO>(){
			new SomeDTO(){
				Prop1 = 5,
				Prop2 = "Hi there"
				// etc},
			new SomeDTO(){
				Prop1 = 6,
				Prop2 = "Goodbye"
				// etc}
			}).AsQueryable();
	}
