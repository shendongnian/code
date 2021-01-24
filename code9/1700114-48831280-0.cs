        using Microsoft.Build.Evaluation;
    using Microsoft.Build.Execution;
    using Microsoft.Build.Logging;
    
    ...
     public static BuildResult Compile(string solution_name, out string buildLog)
            {
                    buildLog = "";
                    string projectFilePath = solution_name;
                    ProjectCollection pc = new ProjectCollection();
                    Dictionary<string, string> globalProperty = new Dictionary<string, string>();
                    globalProperty.Add("nodeReuse", "false");
                    BuildParameters bp = new BuildParameters(pc);
                    bp.Loggers = new List<Microsoft.Build.Framework.ILogger>()
                    {
                        new FileLogger() {Parameters = @"logfile=buildresult.txt"}
                    };
                    BuildRequestData buildRequest = new BuildRequestData(projectFilePath, globalProperty, "4.0",
                        new string[] {"Clean", "Build"}, null);
                    BuildResult buildResult = BuildManager.DefaultBuildManager.Build(bp, buildRequest);
                    BuildManager.DefaultBuildManager.Dispose();
    
                    pc = null;
                    bp = null;
                    buildRequest = null;
    
                    if (buildResult.OverallResult == BuildResultCode.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        if (Directory.Exists("C:\\BuildResults") == false)
                        {
                            Directory.CreateDirectory("C:\\BuildResults");
                        }
                        buildLog = File.ReadAllText("buildresult.txt");
                        Console.WriteLine(buildLog);
                        string fileName = "C:\\BuildResults\\" + DateTime.Now.Ticks + ".txt";
                        File.Move("buildresult.txt", fileName);
                        Console.ForegroundColor = ConsoleColor.Red;
    
                        Thread.Sleep(5000);
                    }
                    Console.WriteLine("Build Result " + buildResult.OverallResult.ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("================================");
    
    
    
    
                    return buildResult;
                
            }
