     public EventHandler txtmessagechanged { get; set; }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                string a = textBox1.Text;
                if (txtmessagechanged != null)
                    txtmessagechanged(a, null);
            }
            else
            {
                MessageBox.Show("Fill some data in textbox");
                e.Cancel = true;
            }
