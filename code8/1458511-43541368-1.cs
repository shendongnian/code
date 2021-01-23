    private static MyRepository SetupRepository( ICollection<Type1> type1s, ICollection<Type2> type2s )
	{
		var mockContext = new Mock<MyDbContext>();
		mockContext.Setup( x => x.Type1s ).ReturnsDbSet( type1s, o => type1s.SingleOrDefault( s => s.Secret == ( Guid ) o[ 0 ] ) );
		mockContext.Setup( x => x.Type2s ).ReturnsDbSet( type2s, o => type2s.SingleOrDefault( s => s.Id == ( int ) o[ 0 ] ) );
		return new MyRepository( mockContext.Object );
	}
