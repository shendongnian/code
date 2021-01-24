            public void DoWork(Action action)
            {
                _task = Task.Run(() => 
                {
                    try
                    {
                        action();
                    }
                    catch (AggregateException ex)
                    {
                        foreach (var innerEx in ex.InnerExceptions)
                        {
                            Logger.Log(innerEx);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex);
                    }
                });
            }
