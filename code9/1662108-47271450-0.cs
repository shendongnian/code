    private List<byte> buffer = new List<byte>();
    private void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        while (sp1.BytesToRead > 0)
        {
            buffer.add(sp1.ReadByte());
        }
        
        //Print if all bytes are available
        if (buffer.Count > 1000)
        {
            foreach(byte b in buffer)
            {
                textBox1.AppendText(b.ToString("X"));
            }
            buffer.Clear();
        }
    }
