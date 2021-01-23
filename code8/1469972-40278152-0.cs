    TfsClientCredentials tcc = new TfsClientCredentials();
                    tcc.AllowInteractive = true;
                    TfsTeamProjectCollection  ttpc = new TfsTeamProjectCollection(new Uri("https://xjsdal.visualstudio.com"), tcc);
                    using (var witClient = ttpc.GetClient<WorkItemTrackingHttpClient>())
                    {
                        var wiql = new Wiql
                        {
                            Query = "SELECT [System.Id] FROM WorkItems WHERE State = 'New'"
                        };
                        var workItems = await witClient.QueryByWiqlAsync(wiql);
                    }
