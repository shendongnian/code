    public void CustomSolutionConfiguration()
    {
        var slnFile = Path.Combine(@"C:\Work\Dev\MvcConfigurations", @"MvcConfigurations.sln");
        
        //VisualStudio.DTE.14.0 this hardcoded string is VS version dependent!
        System.Type t = System.Type.GetTypeFromProgID("VisualStudio.DTE.14.0"); 
        object obj = Activator.CreateInstance(t, true);
        var dte = (DTE2)obj;
        Solution sln = dte.Solution;
        sln.Open(slnFile);
        System.Threading.Thread.Sleep(1000);
        //Do stuff with the solution
    
        var projs = sln.Projects;
        var cnfManager = sln.Projects.Item(1).ConfigurationManager;   
    
        var slnCnfgCount = sln.SolutionBuild.SolutionConfigurations.Count;
        for (var tt = 1; tt <= slnCnfgCount; tt++)
        {   
             Console.WriteLine(sln.SolutionBuild.SolutionConfigurations.Item(tt).Name);
             var tmpItem = sln.SolutionBuild.SolutionConfigurations.Item(tt);
             var tmp = sln.SolutionBuild.SolutionConfigurations.Item(tt).SolutionContexts;
             //Do some test printing
             for (var tt2 = 1; tt2 <= tmp.Count; tt2++)
             {
                 var tmp2 = tmp.Item(tt2);
                 Console.Write(tmp2.ConfigurationName + ";  ");
             }
    
             Console.WriteLine();
         }
    
         sln.SaveAs(slnFile);
         Console.ReadLine();
    }
