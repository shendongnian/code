    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = 0;
        listBox2.SelectedIndexChanged -= listBox2_SelectedIndexChanged;
        while (i < listBox1.Items.Count)
        {
            listBox2.SetSelected(i, listBox1.GetSelected(i));
            i++;
        }
        listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
    }
    
    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = 0;
        listBox1.SelectedIndexChanged -= listBox1_SelectedIndexChanged;
        while (i < listBox2.Items.Count)
        {
            listBox1.SetSelected(i, listBox2.GetSelected(i));
            i++;
        }
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
    }
