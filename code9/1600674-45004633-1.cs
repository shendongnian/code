            Console.WriteLine("Please Provide your Test Plan id");
            int testplanid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Provide your testpoint id");
            int testpointid = Convert.ToInt32(Console.ReadLine());
            
            var u = new Uri("Your account url");
            VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "Your PAT"));
            TfsTeamProjectCollection _tfs = new TfsTeamProjectCollection(u, c);
            ITestManagementService test_service = (ITestManagementService)_tfs.GetService(typeof(ITestManagementService));
            ITestManagementTeamProject _testproject = test_service.GetTeamProject("Your Project name");
            ITestPlan _plan = _testproject.TestPlans.Find(testplanid);
            ITestRun testRun = _plan.CreateTestRun(false);
            testRun.Title = "TestStep Updation Trail1";
            ITestPoint point = _plan.FindTestPoint(testpointid);
            testRun.AddTestPoint(point, test_service.AuthorizedIdentity);
            testRun.Save();
            testRun.Refresh();
            ITestCaseResultCollection results = testRun.QueryResults();
            ITestIterationResult iterationResult;
            foreach (ITestCaseResult result in results)
            {
                iterationResult = result.CreateIteration(1);
                foreach (ITestStep testStep in result.GetTestCase().Actions)
                {
                    String TeststepResult;
                    ITestStepResult stepResult = iterationResult.CreateStepResult(testStep.Id);
                    Console.WriteLine("Enter the TestStep Outcome:");
                    TeststepResult= Console.ReadLine();
                    if (TeststepResult=="Passed" || TeststepResult=="passed" || TeststepResult=="pass")
                    {
                        stepResult.Outcome = TestOutcome.Passed; 
                    }
                    else
                    {
                        stepResult.Outcome = TestOutcome.Failed;
                    }
                    iterationResult.Actions.Add(stepResult);
                }
                String TestResult;
                Console.WriteLine("Enter the Overall TestCase Result [Passed/Failed] :");
                TestResult= Console.ReadLine();
                if (TestResult == "Passed" || TestResult == "passed" || TestResult=="pass")
                {
                    iterationResult.Outcome = TestOutcome.Passed;
                    result.Iterations.Add(iterationResult);
                    result.Outcome = TestOutcome.Passed;
                }
                else
                {
                    iterationResult.Outcome = TestOutcome.Failed;
                    result.Iterations.Add(iterationResult);
                    result.Outcome = TestOutcome.Failed;
                }
                result.State = TestResultState.Completed;
                result.Save(true);
            }
            testRun.State = TestRunState.Completed;
            results.Save(true);
            Console.WriteLine("Sucesfully Updated TestCase TestSteps");
            Console.Read();
