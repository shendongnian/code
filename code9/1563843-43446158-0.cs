    DataTable dt = new DataTable();
    List<string[]> list = new List<string[]>();
    int maxItem = 0;
    using (System.IO.TextReader tr = File.OpenText((@"d:\\My File3.log")))
    {
        string line;
        while ((line = tr.ReadLine()) != null)
        {
            string[] items = line.Trim().Split(' ');
            if (maxItem <= items.Count())
            {
                maxItem = items.Count();
            }
            list.Add(items);
        }
        for (int i = 0; i < maxItem; i++)
            dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
        foreach (var items in list)
        {
            dt.Rows.Add(items);
        }
        //show it in gridview 
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
    }
