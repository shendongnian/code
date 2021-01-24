        string[] items = new string[99];
        int a = 0;
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            items[i] = textBox1.Text;
            i++;
            comboBox1.Items.Clear();
            for (int n = 0; n < items.Length; n++) {
                if(items[n] != null) comboBox1.Items.Add(items[n]);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = comboBox1.SelectedIndex;
            MessageBox.Show(a.ToString());
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            items[a] = textBox2.Text;
            comboBox1.Items.Clear();
            for (int n = 0; n < items.Length; n++)
            {
                if (items[n] != null) comboBox1.Items.Add(items[n]);
            }
        }
