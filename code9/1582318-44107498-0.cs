    private void timer1_Tick(object sender, EventArgs e)
    {
        i++;
        // remove old items
        listBox2.Items.Clear();
        foreach (var item in listBox1.Items)
        {
            listBox2.Items.Add(item);
        }
        listBox1.Items.Add(i);
    }
   
