    [TestMethod]
    public void Repo_GetJobHistoryByNames_PassValid_GetAllRecordsBack() {
        //Arrange
        var mockContext = new Mock<IMyContext>();
        mockContext.Setup(_ => _.JobHistories).Returns(allJobHistory);
        var repo = new mySYSSystemHealthRepo(mockContext.Object);
        //Act
        var allJobs = repo.GetJobHistoryByName(DateTime.Parse("01 OCT 2017"), DateTime.Parse("30 OCT 2017"), "TestJob");
        var allEngineers = allJobs.Select(x => x.Engineer);
        //Assert
        Assert.AreEqual(3, allJobs.Count());
        Assert.IsTrue(allEngineers.Contains("supp"));
    }
