    private void button5_Click(object sender, EventArgs e)
    {
        int gTotal = 1;
        var collection = listBox3.Items.Cast<String>().ToList();
        for (int gCount = 0; gCount < collection.Count - 1; gCount++)
        {
            int item;
            if (int.TryParse(collection[gCount], out item)
            {
                gTotal += item;
            }
        }
        label1.Text = gTotal.ToString();
    }
