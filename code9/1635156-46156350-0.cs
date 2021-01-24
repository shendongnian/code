    private readonly object _lock = new object();
    private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock( _lock )
            {
            rxBuffer += serial.ReadExisting(); // adds new bytes to buffer
            }
            try { backgroundWorker1.RunWorkerAsync(); } catch { } // starts background worker if it is not working already.
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            lock( _lock)
            {
            while (rxBuffer.Length > 0) 
            {
                byte b = Convert.ToByte(rxBuffer[0]); // reads in the next byte    
                rxBuffer = rxBuffer.Remove(0, 1); // deletes this byte from the string
           // ... code ... does things do the UI and stuff
           } // end while
           } // end lock
