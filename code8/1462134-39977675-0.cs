      public static async Task Run() 
                {
                    var module = new Module();
        
                    //No timeout
                    await module.Connect(1, CancelAfter(2000));
        
                    try
                    {
                        // Timeout
                         await module.Connect(5, CancelAfter(1000));
                    }
                    catch (Exception)
                    {
        
                        module.Dispose();
                    }
        
                }
        
                public static CancellationToken CancelAfter(int millisecondsDelay) 
                {
                    var token = new CancellationTokenSource();
                    token.CancelAfter(millisecondsDelay);
                    return token.Token;
                }
        
                public class Module : IDisposable
                {
                    public async Task Connect(int count, CancellationToken cancel)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            //This is just to simulte some work Task.Delay can be canceled as well with Task.Delay(500,cancel)
                            await Task.Delay(500);
                            cancel.ThrowIfCancellationRequested();
                        }
                    }
        
                    public void Dispose()
                    {
                        
                    }
                }
