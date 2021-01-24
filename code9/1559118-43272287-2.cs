    [TestMethod]
    public void TestGetBranchList()
    {
        string projectId = "someProjectId";
        var result = Branches.GetBranchList(projectId);
        //Assert if result has expected result.
    }
    [TestMethod]
    public void TestGetProjectList()
    {
        var result = Branches.GetProjectList();
        //Assert if result has expected result.
    }
    [TestMethod]
    public void TestCreateBranch()
    {
        //Prepare TestData
        List<string> projectName = new List<string> {"someProject"};
        string sourceBranch = "sourceBranch"
        string destinationBranch = "destBranch";
        
        Branches branchesObj = new Branches();
        // Call method by passing the test data.
        branchesObj.CreateBranch(projectName, sourceBranch, destinationBranch);
    }
