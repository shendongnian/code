    internal class UnityBridge
    {
        private static UnityBridge _instance;
        private UnityBridge()
        {
            SelectHandler.SelectedHandler = CallExternal;
        }
        public static UnityBridge Create()
        {
            return _instance ?? (_instance = new UnityBridge());
        }
        private void CallExternal(string nameTag)
        {
            var conn = new HubConnection("http://xxx.azurewebsites.net");
            var proxy = conn.CreateHubProxy("MyHub");
            conn.Start().Wait();
            proxy.Invoke("Send", new EngineerAction {ExecutedAction = nameTag});
        }
    }
