    private void button_OrderByDescencing_Click(object sender, EventArgs e)
     {
            List<ListItem> items= new List<ListItem>();
            foreach (ListItem a in lb.Items)
            {
                items.Add(a);
            }
            items=items.OrderByDescending(a => int.Parse(a.Value)).ToList();
            foreach (ListItem a in items)
            {
                 listBox1.Items.Add(a);
            }
    
     }
