        TcpListener listener = new TcpListener(1334);
        listener.Start();
        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());
            string request = sr.ReadLine();
            if(request == "apple")
            {
                Console.WriteLine(request); // Print that to the console so we know it was received okay
                sw.WriteLine("yes\n");
                sw.Flush(); // sw.Flush(); Added here!!
                client.Close();
            }
