    private void port_OnReceiveData(object sender, SerialDataReceivedEventArgs e) {
        SerialPort sp = (SerialPort)sender;
        UpdateTextBox (sp.ReadExisting());
    }
	
    public void UpdateTextBox(string value) {
		if (InvokeRequired)
		{
			this.Invoke(new Action<string>(UpdateTextBox), new object[] {value});
			return;
		}
		textBox_received.Text += value;
	}
