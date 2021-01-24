    private  void DataReceivedHandler(object sender,SerialDataReceivedEventArgs e)
    {
    
                if (e.EventType != SerialData.Chars || !sp.IsOpen)
                {
                   return;
                }
    
                string w = sp.ReadExisting();
               
                if (w != String.Empty)
                {
                    string temperature = "Temperature";
                    string sorted = w.Replace(temperature, Environment.NewLine + temperature);
                    Invoke(new Action(() => richTextBox1.AppendText(sorted)));
                }
    }  
