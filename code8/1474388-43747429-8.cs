    public class MyCalculator
    {
        public async void CalcAsync(
            string name,
            IJavascriptCallback resolve,
            IJavascriptCallback reject)
        {
            try
            {
                if (resolve.IsDisposed)
                    return;
                int i = /* compute i */;
                if (!resolve.IsDisposed)
                   await resolve.ExecuteAsync(i);
            }
            catch (Exception e)
            {
                if (!reject.IsDisposed)
                    await reject.ExecuteAsync(e.ToString());
            }
        }
    }
