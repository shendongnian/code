    var solutionPath = @"path to your solution .sln file";
    var msWorkspace = MSBuildWorkspace.Create();
    var solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;
    var dataProject = solution.Projects.First(c => c.Name == "ProjectName.Data");
    var testProject = solution.Projects.First(c => c.Name == "NameOfProjectYouTest");
    var hasReference = testProject.AllProjectReferences.Any(c => c.ProjectId == dataProject.Id);
