    string address = "127.0.0.1";
    int port = 25000;
    var client = new TcpClient(address, port);
    StreamReader sr = new StreamReader(client.GetStream());
    StreamWriter sw = new StreamWriter(client.GetStream());
    string command = "*99*1##";
    Console.WriteLine("Client->" + command);
    sw.WriteLine(command);
    sw.Flush();
    char[] charArray = new char[100];
    while (true)
    {
        var readByteCount = sr.Read(charArray, 0, charArray.Length);
        if (charArray.Length > 0)
        {
            var data = new string(charArray,0, readByteCount);
            Console.WriteLine(data + " + data");
        }
        else
        {
            break;
        }
    }
    Console.WriteLine("Server closed connection.");
