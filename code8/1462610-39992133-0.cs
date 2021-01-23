    while (!proc.StandardOutput.EndOfStream)
    {
    
      Application.Current.Dispatcher.Invoke(new Action(() =>
         {
        string line = proc.StandardOutput.ReadLine();
        AddTextToTextbox(line);
         }), null);
    
    }
