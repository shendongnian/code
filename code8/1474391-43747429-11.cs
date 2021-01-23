    public class MyCalculator
    {
        public async void CalcAsync(
            string name,
            IJavascriptCallback resolve,
            IJavascriptCallback reject)
        {
            Promisify(resolve, reject, () => /* compute i */);
        }
    }
