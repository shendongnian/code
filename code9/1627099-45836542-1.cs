    private void timer1_Tick(object sender, EventArgs e)
    {
        if (listBox3.Items.Count > 0)
        {
            listBox3.Items[0] = DateTime.Now.ToString("HH:mm:ss");
        }
        else
        {
            //Nothing in the list so add an item.
            listBox3.Items.Add(DateTime.Now.ToString("HH:mm:ss"));
        }
        listBox3.Refresh();
    }
