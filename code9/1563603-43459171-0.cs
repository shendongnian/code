    DataTable dt = new DataTable();
    using (System.IO.TextReader tr = File.OpenText((@"d:\\My File3.log")))
    {
    string line;
    while ((line = tr.ReadLine()) != null)
    {
        string[] items = line.Trim().Split(' ');
        if (dt.Columns.Count < items.Length)
        {
            // Create the data columns for the data table based on the number of items
            // on the first line of the file
            for (int i = dt.Columns.Count; i < items.Length; i++)
                dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
        }
        dt.Rows.Add(items);
    }
    //show it in gridview 
    this.GridView1.DataSource = dt;
    this.GridView1.DataBind();
