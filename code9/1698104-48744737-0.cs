    _mockedScope
	    .Setup(_ => _.Execute<FooService, IList<FooEntity>>(It.IsAny<Func<FooService, IList<FooEntity>>>()))
		.Returns(new List<FooEntity>());
		
		
