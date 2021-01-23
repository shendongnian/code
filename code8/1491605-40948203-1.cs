    static void Main(string[] args)
        {
            DataTable dt = new DataTable("Sample");
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("Add");
            dt.Rows.Add(1, "abc", "hyd");
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            DataColumn newColumn = new DataColumn("Hack", typeof(System.String));
            newColumn.DefaultValue = "Your Default value";
            dt.Columns.Add(newColumn);
            string str = ""; 
        }
