    byte[] buffer = new byte[1000];
    int bufferIndex = 0;
    private void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        while (sp1.BytesToRead > 0 && bufferIndex  < 1000)
        {
            buffer[bufferIndex ] = sp1.ReadByte();
            bufferIndex ++;
        }
        
        //Print if all bytes are available
        if (bufferIndex  >= 1000)
        {
            //Join the bytes to a string using LINQ
            textBox1.Text = String.Join("", buffer.Select(b.ToString("X")));
            bufferIndex = 0;
        }
    }
