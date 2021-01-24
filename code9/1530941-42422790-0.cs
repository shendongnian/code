    public interface INotificationListener
    {
        void OnRegister(string deviceToken);
        void OnMessage(JObject values);
    }
    public interface INotificationService
    {
        string Token { get; }
        void Register();
    }
