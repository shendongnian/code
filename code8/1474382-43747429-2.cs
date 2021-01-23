    public class MyCalculator
    {
        public async void CalcAsync(
            string name,
            IJavascriptCallback resolve,
            IJavascriptCallback reject)
        {
            try
            {
                int i = /* compute i */;
                await resolve.ExecuteAsync(i);
            }
            catch
            {
                await reject.ExecuteAsync();
            }
        }
    }
