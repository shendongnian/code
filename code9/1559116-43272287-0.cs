    [TestMethod]
    public void TestGetBranchList()
    {
        string projectId = "someProjectId";
        var result = Branches.GetBranchList(project, sourceBranch, tagsName);
        //Assert if result has expected result.
    }
    [TestMethod]
    public void TestGetProjectList()
    {
        var result = Branches.GetProjectList();
        //Assert if result has expected result.
    }
