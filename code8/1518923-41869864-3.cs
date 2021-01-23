    // instead of :
    // void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    // you now should have :
    void WhenLineAdded(object sender, EventArgs e)
    {
        while ( communicationObject.LinesQueue.Count > 0 )
        {
            string message = communicationObject.LinesQueue.Dequeue();
            richTextBox1.Text += message;
            string textFilePath =    System.Configuration.ConfigurationManager.AppSettings["textFilePath"];
            using (StreamWriter txt = new StreamWriter(textFilePath, true))
            {
                txt.WriteLine(message);
                txt.Flush();
            }
        }
    }
