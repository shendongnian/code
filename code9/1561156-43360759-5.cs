	class Class2
	{
		private readonly IRepo _repo;
		private readonly IType2Factory _type2Factory;
		public Class2( IRepo repo, IType2Factory type2Factory )
		{
			_repo = repo;
			_type2Factory = type2Factory;
		}
		public void DoSomething()
		{
			var typ2 = _type2Factory.Create( _repo.SomeDataRetrieved() );
		}
	}
