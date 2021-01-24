            [STAThread]
            public static void Main(string[] args)
            {
                AppDomain currentDomain = AppDomain.CurrentDomain;
    
                //Creating SingleInstaceManager
                SingleInstanceManager manager = new SingleInstanceManager();
    
                //Uncommend the following if statement if you want to debug App's Main method
                //if (!System.Diagnostics.Debugger.IsAttached)
                //{
                //    System.Diagnostics.Debugger.Launch();
                //}
    
                try
                {
                    if (ApplicationDeployment.CurrentDeployment.ActivationUri != null)
                    {
                        var query = ApplicationDeployment.CurrentDeployment.ActivationUri?.Query;
    
                        var cmdParams = string.IsNullOrWhiteSpace(query)
                            ? new NameValueCollection(0)
                            : HttpUtility.ParseQueryString(query);
    
                        var updatedArgs = args.ToList();
                        updatedArgs.Add(cmdParams.ToString());
                        args = updatedArgs.ToArray();
                    }
                }
    
                //Empty catch to ignore the annoying InvalidDeploymentException while debuging; 
                catch (InvalidDeploymentException)
                { }
    
                //Passing parameters to the SingleInstaceManager
                manager.Run(args);
            }
