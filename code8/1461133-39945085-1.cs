    public class MainActivity : Activity
    {
        private TextView txt;
        private Client client;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            txt = FindViewById<TextView>(Resource.Id.textView1);
            client = new Client();
            client.WebsocketClient.Opened += websocketClient_Opened;
            client.Setup("ws://192.168.0.14:8001", "basic", WebSocketVersion.Rfc6455);
            client.Start();
        }
        protected override void OnDestroy()
        {
            client.WebsocketClient.Opened -= websocketClient_Opened;
            base.OnDestroy();
        }
        private void websocketClient_Opened(object sender, EventArgs e)
        {
            txt.Text = ("Client successfully connected.");
            // maybe have to be wrapped in a RunOnUiThread(() =>{ ... });
        }
    }
    class Client
    {
        public WebSocket WebsocketClient { get; set; }
        public void Setup(string url, string protocol, WebSocketVersion version)
        {
            // WebsocketClient = new  ...
            WebsocketClient.Opened += websocketClient_Opened;
        }
        private void websocketClient_Opened(object sender, EventArgs e)
        {
            WebsocketClient.Send("Hello World!");
        }
    }
