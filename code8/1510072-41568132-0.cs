    class Program
        {
            static void Main(string[] args)
            {
                DataSet ds = new DataSet();
                FillDataSet(ds);
            }
           private static void FillDataSet(DataSet ds)
           {
            DataSet ds2 = new DataSet();//Say you have created an new instance of Class DataSet.
            
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            ds2.Tables.Add(dt);
            ds = ds2; //here ds is now referencing address of ds2 created by new DataSet()
           }
        }
