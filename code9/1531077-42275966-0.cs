    private void button1_Click(object sender, System.EventArgs e)
    {
        listBox1.Items.Add("One");
        listBox1.Items.Add("Two");
        listBox1.Items.Add("Three");
        listBox1.SelectedIndex = listBox1.FindString("Two");
    }
