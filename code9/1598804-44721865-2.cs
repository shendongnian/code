    public interface IUpdateProgess
    {
        void SendMessage(string val);
    }
    public async Task<object> MyAsyncMethod(IUpdateProgess progress)
    {
        //UI thread
        SynchronizationContext context = SynchronizationContext.Current;
        return await Task.Run<object>(() =>
        {
            //other thread
            if (context != null && progress != null)
            {
                context.Post(new SendOrPostCallback((o) =>
                {
                    progress.SendMessage("Progress");
                }), null);
            }
            return null;
        });
    }
