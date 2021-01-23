    public static void listen(IPEndPoint server_ip)
    {
        Console.WriteLine("In listen");
        while (true)
        {
            try
            {
                byte[] received_bytes = udp_client.Receive(ref server_ip);
                string received_data = Encoding.ASCII.GetString(received_bytes);
                Record record = JsonConvert.DeserializeObject<Record>(received_data);
                theForm.AddRecord(record); // You need a Form instance.
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
