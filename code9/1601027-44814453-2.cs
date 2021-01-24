    private void read()
    {
        foreach(Person p in list)
        {
            ListViewItem item = new ListViewItem();
            item.Text = p.Name;
            item.SubItems.Add(p.Position);
            item.SubItems.Add(p.Team);
            lstvPerson.Items.Add(item);            
        }
    }
