    Task t = Task.Run(() =>
                {
					//do the connection thing
					Connection();
					connectionDone.Set(); //Manualeventreset connectionDone = new ManualResetEvent(false);
                });
            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
				//write the exception somewhere
                WriteLog("Exception in task: " + ae);
            }
            finally
            {
                connectionDone.Reset();
            }
