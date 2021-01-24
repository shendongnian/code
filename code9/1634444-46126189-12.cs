    var table = new DataTable();
    table.Columns.Add("ID", typeof(string));
    foreach (ListItem item in listBox.Items.Where(i => i.Selected))
    {
        table.Rows.Add(item.Text);
    }
