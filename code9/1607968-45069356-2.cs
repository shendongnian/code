    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        var item = listBox1.Items[e.Index] as ColoredItem;
        if (item != null)
        {
            e.Graphics.DrawString(
                item.Text, 
                e.Font, 
                new SolidBrush(item.Color), 
                e.Bounds);
        }
    }
