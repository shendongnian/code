    public void MethodToTest( IRepository repository )
    {
        var rq = new RestBaseRequest{AmendHeaders = x => x.Add("Systerm", "Portal")};
        var repositoryResponse = await repository.GetAsync(rq,cancellationToken, loggingContext);
    }
    public void TheTest()
    {
         repositoryMock.Setup( x => x.GetAsync(...) ).Callback( (x,y,z) =>
         {
             var headers = new HttpRequestHeaders();
             x.AmendHeaders( headers );
             Assert.That( headers["System"], Is.EqualTo( "Portal" ) );
         });
         _subjectUnderTest.MethodToTest( repositoryMock.Object );
    }
