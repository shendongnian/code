        private void button1_Click(object sender, EventArgs e)
        {
            DateTime t1 = DateTime.Now;
            DateTime t2 = Convert.ToDateTime(textBox1.Text);
            int i = DateTime.Compare(t1, t2);
            if (i < 1)
            {
            }
        }
