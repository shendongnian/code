    public class MyCalculator
    {
        public async void CalcAsync(
            string name,
            IJavascriptCallback resolve,
            IJavascriptCallback reject)
        {
            try
            {
                var i = await DoSomeCalculationAsync(name);
                await resolve.ExecuteAsync(i);
            }
            catch
            {
                await reject.ExecuteAsync();
            }
        }
    }
