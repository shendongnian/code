            public async void DoSomething()
            {
                await RunSafe(async () =>
                {
                    await model.DoSomething();
                    await model.DoSomethingElse();
                    await model.DoLastThing();
                });
            }
            private async Task RunSafe(Func<Task> del, [CallerMemberName] String methodName = "")
            {
                try
                {
                    Log.Info("Executing {0}", methodName);
                    await del();
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Error in {0}(...): {1}\r\n{2}", methodName, ex.Message, ex.ToString());                
    
                    Log.Error("Error occured in plug in.", ex);
                }
            }
