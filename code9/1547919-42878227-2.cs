    private string ReadPipe()
    {
        string line = "";
        using (NamedPipeClientStream client =
            new NamedPipeClientStream(".", Environment.UserName, PipeDirection.InOut))
        {
            client.Connect();
            using (StreamReader sr = new StreamReader(client))
            {
                line = sr.ReadLine();
            }
            return line;
        }
    }
