    private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(! String.IsNullOrEmpty(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text);
            }
            if(! String.IsNullOrEmpty(textBox2.Text))
            {
                listBox1.Items.Add(textBox2.Text);
            }
            if (radioButton1.Checked == true)
            {
                listBox1.Items.Add("Male");
            }
            else if (radioButton2.Checked == true)
            {
                listBox1.Items.Add("Female");
            }
        }
