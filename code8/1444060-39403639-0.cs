    class Program
    {
        static void Main(string[] args)
        {
            string ur = "https://xxxxxxx/";
            TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(ur));
            //Get build information
            BuildHttpClient bhc = ttpc.GetClient<BuildHttpClient>();
            string projectname = "Project";
            int buildId = 1;
            Build bui = bhc.GetBuildAsync(projectname,buildId).Result;
            //Get test run for the build
            TestManagementHttpClient ithc = ttpc.GetClient<TestManagementHttpClient>();
    
            Console.WriteLine(bui.BuildNumber);
    
            QueryModel qm = new QueryModel("Select * From TestRun Where BuildNumber Contains '" + bui.BuildNumber + "'");
            
            List<TestRun> testruns = ithc.GetTestRunsByQueryAsync(qm,projectname).Result;
            foreach (TestRun testrun in testruns)
            {
    
                List<TestCaseResult> testresults = ithc.GetTestResultsAsync(projectname, testrun.Id).Result;
                foreach (TestCaseResult tcr in testresults)
                    {
                        Console.WriteLine(tcr.TestCase.Name);
                        Console.WriteLine(tcr.Outcome);
                    }
                
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
