    //Configure Project
    var demoProject = new ProjectInfo($"DemoProject", ProjectTemplate.WindowsClassicDesktopWindowsFormsApp);
    demoProject.NugetPackages = new List<string> { "System.ServiceModel.NetTcp", "System.Runtime.Serialization.Xml" };
    //Configure Solution
    var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    var solutionInfo = new SolutionInfo("Test", folder);
    solutionInfo.ProjectInfos.Add(demoProject);
    //Start building machine
    var buildingMachine = new SolutionBuildingMachine();
    buildingMachine.Build(solutionInfo);
    buildingMachine.Dispose();
