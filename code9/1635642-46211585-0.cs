     private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e) // the Main serial receiving event.
        {
             lock (_lock)
             {
                rxBuffer += serial.ReadExisting();
             }
            serialReceived(rxBuffer);
        }
        private void serialReceived(string value)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new serialReceivedDelegate(serialReceived), new object[] { value });
            }
            else
            {
                lock (_lock)
                {
