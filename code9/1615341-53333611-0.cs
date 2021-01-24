    int Failed = 0;
    int Passed = 0;
    var TestCases = TestSuite.Current.SelectedRunConfig.GetActiveTestContainers();
            foreach(var testcase in TestCases){
            {if(testcase.IsTestCase){ //To Handle Smart Folders
            		if(testcase.Status.ToString()=="Failed")
            			{
            			Failed++;
            			}
            		Passed++;
            	}
            	}
            }
            Report.Log(ReportLevel.Info, "Passed Count :"+Passed);
            Report.Log(ReportLevel.Info, "Failed Count :"+Failed);
        }
