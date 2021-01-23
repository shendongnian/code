    public void SetTextBoxText(string value)
        {
            if (textBox1.InvokeRequired)
            {
                try
                {
                    textBox1.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                    return;
                }
                catch (ObjectDisposedException)
                {
                    thrIsAlive = false;
                }
            }
            textBox1.Text += value;
        }
