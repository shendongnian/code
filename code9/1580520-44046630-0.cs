        private static async Task BlockInput(TimeSpan span)
        {
            return Task.Run(()=>{
                try
                {
                    NativeMethods.BlockInput(true);
                    await Task.Delay(span);
                }
                finally
                {
                    NativeMethods.BlockInput(false);
                }
               
            });
            
        }
