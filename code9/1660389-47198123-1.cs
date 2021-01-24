    private void button5_Click(object sender, EventArgs e)
    {
        int gTotal = 1;
    
        for (int gCount = 0; gCount < listBox3.Items.Count; gCount++)
             gTotal += int.Parse(listBox3.Items[gCount].ToString()); 
             // assuming all items in the listbox is an int.
    
        label1.Text = gTotal.ToString();
    }
