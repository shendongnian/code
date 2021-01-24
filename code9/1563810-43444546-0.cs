    using (OleDbConnection cn = new OleDbConnection())
        {
            using (OleDbCommand cmd = new OleDbCommand())
            {
                cn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\jediablaza\Documents\EDIExcel\EDIExcel.xls" + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * from [Sheet1$]";
                using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    using (StreamWriter wr = new StreamWriter(@"C:\Users\jediablaza\Documents\EDIExcel\EDIExcel.txt"))
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                                var strBldr = new StringBuilder();
                                foreach (var r in row)
                                {
                                    strBldr.Append("{r}\t");
                                }
                                wr.WriteLine(strBldr);
                        }
                    }
                }
            }
        }
