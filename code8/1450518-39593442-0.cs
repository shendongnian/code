    var mock = MockRepository.GenerateMock<IInterface>();
    using (mock.GetRepository().Ordered())
    {
       mockFoo.Expect(x => x.GetAll(null)).IgnoreArguments().Return(result1);
       mockFoo.Expect(x => x.GetAll(null)).IgnoreArguments().Return(result2);
    }
    mock.Replay();
    
    // rest of the test goes here...
    mock.VerifyAllExpectations();
