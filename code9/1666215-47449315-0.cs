    public async static void Main()
    {
        var result = await GetSometing("abc", "def", "ghi");
        Console.ReadKey();
    }
    public static Task<int> GetSometing(string pluginId, string arg1, string arg2)
    {
        var plugin = new PluginMock();
        var tcs = new TaskCompletionSource<int>();
        plugin.RegisterCallback(result =>
        {
            tcs.SetResult(result);
        });
        plugin.RequestData(arg1, arg2);
        return tcs.Task;
    }
    public class PluginMock
    {
        private Action<int> _callback;
        public void RegisterCallback(Action<int> callback)
        {
            _callback = callback;
        }
        public void RequestData(string arg1, string arg2)
        {
            var thread = new Thread(() =>
            {
                Thread.Sleep(1000);
                _callback(42);
            });
        }
    }
