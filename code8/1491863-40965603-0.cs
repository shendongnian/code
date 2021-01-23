    public class Class1
    {
        public static async Task<string> Fetch(string url, Action onComplete = null)
        {
            await Task.Delay(10);
            onComplete?.Invoke();
            return url;
        }
    }
