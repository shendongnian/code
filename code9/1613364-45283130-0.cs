    public partial class MyClass
    {
        public DataSet GenerateDataSet(MyClass source)
        {
            return GenerateDataSet(new[] { source });
        }
        public DataSet GenerateDataSet(IEnumerable<MyClass> source)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            dt.Columns.Add("Name");
            dt.Columns.Add("Id", typeof(int));
            // other columns...
            foreach (MyClass c in source)
            {
                DataRow dr = dt.Rows.Add();
                dr.SetField("Name", c.Name);
                dr.SetField("Id", c.Id);
                // other properties
            }
            return ds;
        }
    }
