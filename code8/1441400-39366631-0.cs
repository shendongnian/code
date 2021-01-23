     public void DoWork()
                {
                    var t = new Thread(() =>
                    {
                        while (true)  
                        {
                           Log.Debug("Service", "Service running");    
                            Thread.Sleep(5000);
                        }
                    });
                    t.Start();
                }
