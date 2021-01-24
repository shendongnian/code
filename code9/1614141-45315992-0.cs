        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char _enter = (char)13;
            if (e.KeyChar == _enter && isFirstStringContaining1())
                textBox2.Text = "PASS";
            else
                textBox2.Text = "";
        }
        private bool isFirstStringContaining1()
        {
            int length = textBox1.Text.IndexOf(' ');
            if (length == -1)
                length = textBox1.Text.Length;
            string first_str = textBox1.Text.Substring(0, length);
            foreach (char c in first_str)
                if (c.Equals('1'))
                    return true;
            return false;
        }
