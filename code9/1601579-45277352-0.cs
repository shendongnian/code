    using (var client = new SvnClient())
                {
                    SvnLogArgs logArgs = new SvnLogArgs();
                    Collection<SvnLogEventArgs> logResults;
                    if (client.GetLog(new Uri("RepositoryUri"), logArgs, out logResults))
                    {
                        foreach (var logResult in logResults)
                        {
                            if (logResult.ChangedPaths.Contains("searchedPath"))
                            {
                                // do something with the information
                            }
                        }
                    }                    
                    return;
                }
