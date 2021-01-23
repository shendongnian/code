        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "root" && textBox2.Text == "toor") // there was a ; at the end of the if
            {
                progressBar1.Increment(100);
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
