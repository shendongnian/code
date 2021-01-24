    NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut, 4);
    StreamReader sr = new StreamReader(pipeServer);
    StreamWriter sw = new StreamWriter(pipeServer);
    do
    {
        try
        {
            pipeServer.WaitForConnection();
            string test;
            sw.WriteLine("Waiting");
            sw.Flush();
            pipeServer.WaitForPipeDrain();
            
            // start inner loop
            while(pipeServer.IsConnected)
            {
                test = sr.ReadLine();
                Console.WriteLine(test);
                if (test.Contains("Mouse"))
                {
                    Invoke((Action)delegate
                    {
                        listBox1.Items.Add(test);
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    });
                 }
                 if (test.Contains("Bt1"))
                 {
                     Invoke((Action)delegate
                     {
                         listBox2.Items.Add("BT");
                     });
                 }
                 // close command
                 if (test == "Close")                 
                     pipeServer.Disconnect();               
             }
         }
         catch (Exception ex) { throw ex; }
         finally
         {
             //If i remove this line, The code Work
             //pipeServer.WaitForPipeDrain();
             //if (pipeServer.IsConnected) { pipeServer.Disconnect(); }
         }
     } while (true);
