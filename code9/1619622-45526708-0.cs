    if (item.SubItems.Any(t => t.Text == code))
        MessageBox.Show("Code or Department name already exist");
    else
    {
        item.Text = (serial.ToString());
        item.SubItems.Add(code);
        item.SubItems.Add(name);
        listView1.Items.Add(item);
    }
