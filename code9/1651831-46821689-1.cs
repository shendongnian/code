    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Repo_GetJobHistoryByNames_PassAllNull_ArgumenNullException() {
        //Arrange
        ImySSystemHealthRepo repo = new MyActualSystemHealthRepo(context: null);
        //Act
        var allJobs = repo.GetJobHistoryByName(default(DateTime), default(DateTime), null);
        //Assert
        //...N/A
    }
