    private List<byte> buffer = new List<byte>();
    private void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        while (sp1.BytesToRead > 0)
        {
            buffer.add(sp1.ReadByte());
        }
        
        //Print if all bytes are available
        if (buffer.Count >= 1000)
        {
            //Join the bytes to a string using LINQ
            textBox1.Text = String.Join("", buffer.Select(b.ToString("X")));
            buffer.Clear();
        }
    }
