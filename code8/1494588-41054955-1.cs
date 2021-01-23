    public delegate void UpdateTextCallback(object sender, messageReceivedEventArgs e);
    private void appendTextBox(object sender, messageReceivedEventArgs e)
    {
            if (textBox1.InvokeRequired)
            {
                listBox1.Invoke(new UpdateTextCallback(appendTextBox), new object[] { sender, e });  // invoking itself
            }
            else
            {
                textBox1.Text += e.message;
            }
    }
