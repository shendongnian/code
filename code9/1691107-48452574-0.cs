      private void Form1_Load(object sender, EventArgs e)
            {
                textBox1.Text= "SendKeys.Send(^{v}); ";
                Clipboard.SetText(textBox1.Text);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                textBox2.Focus();
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
            }
