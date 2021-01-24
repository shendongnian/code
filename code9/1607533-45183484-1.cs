     DispatcherClient dispatcherClient = new DispatcherClient(new DispatcherCallBack(), "dispatcherEndPoint", Token, Global.Cluster);
                        Task.Run(() =>
                        {
                            studies = new List<Study_C>();
                            try
                            {
                                ManualResetEvent ev = new ManualResetEvent(false);
                                dispatcherClient.AnnuncedSPError += (s, e) =>
                                {
                                    spErrorMessage += e.ServicePointName + "<br/>";
                                };
                                dispatcherClient.AnnuncedFindStudies += (s, e) =>
                                { 
                                    lock (studies)
                                    {
                                        studies.AddRange(e.Studies);
                                    }
                                };
                                dispatcherClient.AnnuncedComplete += (s, e) =>
                                {
                                    ev.Set();
                                };
                                var rrr = dispatcherClient.FindStudies(new FindStudies_DTO_IN(startIndex, numberOfRows, col.FromText(sortColumnName), sort.FromText(sortOrder), criteria, searchMatching)).Studies;
                                ev.WaitOne();
                            }
                            catch (Exception exp)
                            {
                                Logging.Log(LoggingMode.Error, "Failed to Find Studies by Dispatcher, EXP:{0}", exp);
                            }
                        }).Wait(dispatcherClient.Endpoint.Binding.ReceiveTimeout);
