    private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            rxBuffer += serial.ReadExisting();
            try { backgroundWorker1.RunWorkerAsync(); } catch { }
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //private void serialReceived(object s, EventArgs e)
            //{
            while (rxBuffer.Length > 0)
            {
                // textBox1.Text += rxBuffer[0];
                byte b = Convert.ToByte(rxBuffer[0]);
                string hexValue = b.ToString("X");
                rxBuffer = rxBuffer.Remove(0, 1);
