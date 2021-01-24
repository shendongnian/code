    public class SocketIOAdapter {
    
        SocketIOComponent socketIO;
        protected Thread socketThread;
        public SocketIOAdapter(string url)
        {
            socketIO = new SocketIOComponent(url);
        }
    
        public void Connect()
        {
            socketIO.Connect();
            socketThread = new Thread(socketIO.Update);
            socketThread.Start();
        }
    
        public void Emit(string eventName, JSONObject json)
        {
            socketIO.Emit(eventName, json);
        }
    
        public void On(string eventName, System.Action<SocketIOEvent> callback)
        {
            socketIO.On(eventName, callback);
        }
    }
