    bool isClientConnected = false;
    var connector = new System.ComponentModel.BackgroundWorker();
    public void connectToUDP(){
        connector.DoWork+= connect;
        connector.RunWorkerAsync();
    } 
 
     private void connect(object sender, DoWorkEventArgs e)
    {          
        IPAddress server_address = IPAddress.Parse("127.0.0.1");
        IPEndPoint server_ip = new IPEndPoint(server_address, 5685);
        Console.WriteLine("2");
        
                    try
            {
                Console.WriteLine("Waiting for server...");
                udp_client.Connect(server_ip);
                byte[] send_data = Encoding.ASCII.GetBytes("INIT");
                udp_client.Send(send_data, send_data.Length);
                byte[] received_bytes = udp_client.Receive(ref server_ip);
                string received_data = Encoding.ASCII.GetString(received_bytes);
                if (received_data == "INIT")
                {
                    isClietConnected = true;
                    Console.WriteLine("now connected");
                    listen(server_ip);
                }
           
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        
    }
    public bool sendReceiveUDP(string send){
         if(!isClientConnected){
              return false;
         }
         //perform send
         return true;
     }
