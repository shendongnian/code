    public class MyDataTable : DataTable
    {
        public MyDataTable()
        {
            Columns.Add("Data1", typeof(string));
            Columns.Add("Data2", typeof(string));
            Columns.Add("Data3", typeof(string));
    
            DataRow dr;
            var r = new Random();
            for (int i = 0; i < 1000; i++)
            {
                dr = NewRow();
                dr["Data1"] = r.Next(1111, 9999);
                dr["Data2"] = r.Next(1111, 9999);
                dr["Data3"] = r.Next(1111, 9999);
                Rows.Add(dr);
            }
        }
    }
