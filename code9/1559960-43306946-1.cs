    public class Service2 : IService2
    {
        public void insertExecl(DataSet rslt)
        {
            DataClasses1DataContext conn = new DataClasses1DataContext();
    
            foreach (DataTable table in rslt.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    tblExcel addTbl = new tblExcel()
                    {
                        SID = Convert.ToString(dr[0]),
                        Name = Convert.ToString(dr[1]),
                        Address = Convert.ToString(dr[2])
                    };
                    conn.tblExcels.InsertOnSubmit(addTbl);
                }
            }
    
    
            conn.SubmitChanges();
    
            //excldr.Close();
            //strm.Close();
            Console.WriteLine("successfully");
    
        }
    }
