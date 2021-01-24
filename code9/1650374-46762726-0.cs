        if (!connected)
            return;
        using (var pipe = new NamedPipeClientStream(".", "TestPipe", PipeDirection.Out))
        {
          using (var stream = new StreamWriter(pipe))
          {
           pipe.Connect();
           stream.Write(TextBox.Text);
           pipe.Flush();
          }
        }
    }`
