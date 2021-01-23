        void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            printReceivedText(_PuertoSerial.ReadExisting());
        }
        private void printReceivedText(string text)
        {
            if (this.txtSend.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(printReceivedText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtRecieve.AppendText(text);
                _PuertoSerial.DiscardInBuffer();
            }
        }
