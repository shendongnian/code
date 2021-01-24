    public class ClientConnectionServiceProxy : ClientBase<IClientConnectionService>
    {
        public bool Connect(string message)
        {
            return base.Channel.Connect(message);
        }
    }
