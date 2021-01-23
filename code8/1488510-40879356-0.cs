    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    
    namespace TFSDownloadFile
    {
        class Program
        {
            static void Main(string[] args)
            {
                string url = "http://tfscollectionurl/";
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(url));
                ITestManagementService itms = ttpc.GetService<ITestManagementService>();
                ITestManagementTeamProject itmtp = itms.GetTeamProject("YourProject");
                //Get test case with test case id
                ITestCase itc = itmtp.TestCases.Find(1);
                //Get the first step in test case
                ITestStep teststep = itc.Actions[0] as ITestStep;
                //Update the test step
                teststep.Title = "New Title";
                teststep.ExpectedResult = "New ExpectedResult";
                //Save the updated test case
                itc.Save();
            }
        }
    }
