    private void Window_Loaded(object sender, RoutedEventArgs e)
    {   
        var callback = new WindowInteropHelper(this).Handle;
        BackgroundWorker bg = new BackgroundWorker();
        bg.DoWork += (s, a) =>
        {
            WritePipe("at loaded evt: " + callback);
        };
        bg.RunWorkerAsync();
    }
    
    private void WritePipe(string line)
    {
        using (NamedPipeServerStream server = 
            new NamedPipeServerStream(Environment.UserName, PipeDirection.InOut))
        {
            server.WaitForConnection();
            using (StreamWriter sw = new StreamWriter(server))
            {
                sw.WriteLine(line);
            }
        }
    }
