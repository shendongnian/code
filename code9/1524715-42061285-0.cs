    public void Test()
    {
        string filePath = $"{Environment.CurrentDirectory}//test20170206.xls";
        string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1;'";
        //connection excel
        OleDbConnection conn = new OleDbConnection(conStr);
        conn.Open();
        //get all sheel from excel file
        DataTable tb = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        foreach (DataRow row in tb.Rows)
        {
            Console.WriteLine(row["TABLE_NAME"]);
            //using index in row
            for (int i=0;i< row.ItemArray.Length;i++)
                Console.WriteLine(row[i]);
        }
        //below line is getting by index, but the order inconsistency.
        //can't ensure index 0 is you want.
        //tb.Rows[0]["TABLE_NAME"];
        //read all datas into DATASET
        DataSet ds = new DataSet();
        OleDbDataAdapter myCommand = new OleDbDataAdapter("select * from [sfsdfedf$]", conStr);
        myCommand.Fill(ds, "table1");
        conn.Close();
        conn.Dispose();
    
        //convert DataRowCollection to DataRow[]
        var data = ds.Tables[0].Select();
        //using Linq query data
        var result = from d in (
                    from c in data
                        //filter null  data
                    where c[0] != DBNull.Value && c[1] != DBNull.Value
                    select new Model20170206
                    {
                        Id = Convert.ToInt32(c[0]),
                        Datetime = Convert.ToDateTime(c[1]),
                        Value1 = c[2]?.ToString(),
                        Value2 = c[3]?.ToString(),
                        Value3 = c[4]?.ToString(),
                        Value4 = c[5]?.ToString()
                    }
                    )
                     orderby d.Id, d.Datetime
                     //group by ID and Datetime.Date
                     group d by new { d.Id, Date = d.Datetime.ToLongDateString() } into g
                     select new { g.Key.Id, g.Key.Date, TimeMin = g.Min(p => p.Datetime).ToLongTimeString(), TimeMax = g.Max(p => p.Datetime).ToLongTimeString() };
    
    
    }
    
    public class Model20170206
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
    }
