    [TestMethod]
    public void Should_Save_If_Has_Data()
    {
       Given(Web_Service_Instance)
         With(Data_To_Pass)
         When(Posting_Data_To_Service)
         Then(Data_Will_Be_Saved)
         Verify()
    }
    [TestMethod]
    public void Should_Not_Save_If_No_Data()
    {
        .....
    }
