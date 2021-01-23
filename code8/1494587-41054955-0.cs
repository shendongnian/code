    public delegate void UpdateTextCallback(string text);
    private void appendTextBox(object sender, messageReceivedEventArgs e)
    {
            if (textBox1.InvokeRequired)
            {
                listBox1.Invoke(new UpdateTextCallback(appendTextBox), new object[] { text });  // invoking itself
            }
            else
            {
                textBox1.Text += e.message;
            }
    }
