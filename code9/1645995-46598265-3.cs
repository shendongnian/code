        public void readData()
        {
            try
            {
                serialPort.DataReceived += SerialPort_DataReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string res = serialPort.ReadExisting();
            Thread.Sleep(500);
            txtResult.Invoke(this.objDelegate, new object[] {res});
        }
        
        public void getText(string text)
        {
            txtResult.Text = text;
        }
