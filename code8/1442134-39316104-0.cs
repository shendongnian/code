    private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        var column = listView1.Columns[e.Column];
        var tag = column.Tag as string;
        if(tag == "something")
        {
            //...
        }
    }
