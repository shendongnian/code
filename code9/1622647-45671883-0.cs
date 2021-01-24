    public ISharedStep tstSharedStep { get; private set; }
    
    public ISharedStepReference tstSharedStepRef { get; private set; }
    
        foreach (ITestAction tstAction in tstCase.Actions)
                {
                    tstSharedStep = null; 
                    tstSharedStepRef = tstAction as ISharedStepReference;
                        if (tstSharedStepRef != null)
                        {
                            tstSharedStep = tstSharedStepRef.FindSharedStep();
                            foreach (ITestAction tstSharedAction in tstSharedStep.Actions)
                            {
                                ITestStep tstSharedTestStep = tstSharedAction as ITestStep;
                                resultData.Step = Regex.Replace(tstSharedTestStep.Title, @"<[^>]+>|&nbsp;", "").Trim();
                                resultData.ExpectedResult = Regex.Replace(tstSharedTestStep.ExpectedResult, @"<[^>]+>|&nbsp;", "").Trim();
                               
                            }
                        }
                        else {
                         // regular step action
                        }
    
    }
