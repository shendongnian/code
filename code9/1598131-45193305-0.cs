    while (true)
    {
        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
        try
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                using (var client = new UdpClient())
                {                           
                    client.Send(data, data.Length, "192.168.1.145", 55600);   
                }                       
            });
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
            Console.WriteLine("    ");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        System.Threading.Thread.Sleep(1000);   // to see easily
     }
