    [TestMethod]
    public void TestMethod1()
    {
        const string FIRST = "First Name";
        const string SECOND = "Second Name";
        var reader = MockRepository.GenerateStub<IDataReader>();
        reader.Stub(x => x.FieldCount).Return(2);
        reader.Stub(x => x.GetName(0)).Return(FIRST);
        reader.Stub(x => x.GetName(1)).Return(SECOND);
        var actual = RetrieveColumnNames(reader);
        CollectionAssert.AreEquivalent(new [] {FIRST, SECOND}, actual);
        
    }
