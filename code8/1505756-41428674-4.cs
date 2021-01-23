    private async void receiveMessage()
    {
         using(var udpClient = new UdpClient(15000))
         {
             while(true)
             {
                 var receivedResult = await udpClient.ReceiveAsync();
                 Console.Write(Encoding.ASCII.GetString(receivedResult.Buffer));
             }
         }
    }
