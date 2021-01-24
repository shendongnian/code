    [TestMethod]
    public async void FourDividedByTwoIsTwoAsync()
    {
        bool result = ExamStatus.BlobFileUploadPost(ExamDetails); 
        Assert.AreEqual(true, result);
    }
   
