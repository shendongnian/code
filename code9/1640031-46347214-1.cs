    public class MyMsgType
    {
        public static short texture = MsgType.Highest + 1;
    };
    
    //Create a class that holds a variables to send
    public class TextureMessage : MessageBase
    {
        public byte[] textureBytes;
        public string message;//Optional
    }
    
    NetworkClient myClient;
    
    // Create a client and connect to the server port
    public void setupClient()
    {
        //Create new client
        myClient = new NetworkClient();
        //Register to connect event
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        //Register to texture receive event
        myClient.RegisterHandler(MyMsgType.texture, OnTextureReceive);
    
        //Connect to server
        myClient.Connect("127.0.0.1", 4444);
    }
    
    //Called when texture is received
    public void OnTextureReceive(NetworkMessage netMsg)
    {
        TextureMessage msg = netMsg.ReadMessage<TextureMessage>();
    
        //Your Received message
        string message = msg.message;
        Debug.Log("Texture Messsage " + message);
    
        //Your Received Texture2D
        Texture2D receivedtexture = new Texture2D(4, 4);
        receivedtexture.LoadRawTextureData(msg.textureBytes);
        receivedtexture.Apply();
    }
    
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }
