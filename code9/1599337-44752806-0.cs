    string i = "{\"cmd\" : \"get_id_list\"}";
    UdpClient client = new UdpClient();
    
    client.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.112"), 9898));
    Byte[] buffer = null;
    buffer = Encoding.Unicode.GetBytes(i.ToString());
    client.Send(buffer, buffer.Length, ep);
    byte[] b2 = client.Receive(ref ep);
    string str2 = System.Text.Encoding.ASCII.GetString(b2, 0, b2.Length);
