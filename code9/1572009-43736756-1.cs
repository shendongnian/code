    private void listboxlrm(byte[] text)
    {
        if (this.listBox2.InvokeRequired)
        {
            SetTextCallback d = new SetTextCallback(listboxlrm);
            this.Invoke(d, new object[] { text });
        }
        else
        {
            byte[] convert = new byte[text[4]];
            Array.Copy(text, 6, convert, 0, text[4]);
            string yourtext = System.Text.Encoding.UTF8.GetString(convert);
            this.listBox2.Items.Insert(0, string.Format(yourtext));
        }
    }
