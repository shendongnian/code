     public EventHandler txtmessagechanged { get; set; }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            string a = textBox1.Text;
            if (txtmessagechanged != null)
                txtmessagechanged(a, null);
        }
