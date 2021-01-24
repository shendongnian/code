    var table = new DataTable();
    table.Columns.Add("ID", typeof(string));
    foreach (ListItem item in listbox.Items)
    {
        if (item.Selected)
        {
            table.Rows.Add(item.Text);
        }
    }
    var param = new SqlParameter("@List", SqlDbType.Structured);
    param.TypeName = "dbo.MyList";
    param.Value = dataTable;
    cmd.ExecuteNonquery();
