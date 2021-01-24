     static void Main(string[] args){
    // create client instance
    MqttClient client = new MqttClient(IPAddress.Parse("127.0.0.1"), 8883,   true, null, null, MqttSslProtocols.TLSv1_2);
        // register to message received
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        string clientId = "pahoSubscriber2";
        client.Connect(clientId);
        // subscribe to the topic "hello" with QoS 0
        client.Subscribe(new string[] { "hello" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
    }
    static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        // handle message received
        Console.WriteLine(e.Message);
    }
