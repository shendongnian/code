    public class MyHub : Hub
    {
        public string msg = "Initializing hub...";
        public void CallLongOperation(int progressStatus)
        {
            Newtonsoft.Json.Linq.JObject jsonMessage = Newtonsoft.Json.Linq.JObject.Parse(@"{
                          'msg': 'message',
                          'value': "someValue"}");
            Clients.Caller.sendMessage(jsonMessage.ToString());
        }
    }
