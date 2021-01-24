    public class Main
    {
        public DataTable myMethod()
        {
            try
            {
                DataTable myTable = new DataTable("MyDataTable");
    
                using (SqlCommand CMD = new SqlCommand())
                {
                    CMD.Connection = RBOSUtil.DBConnection();
                    CMD.CommandType = CommandType.Text;
                    //this is the part I used the string from other class
                    CMD.CommandText = OtherClas.myQuery;
                    CMD.Parameters.Add("@code", varchar(max)).value= _obj.code;
                    using (SqlDataAdapter DA = new SqlDataAdapter(CMD))
                    {
                        DA.Fill(myTable);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //close connection
            }
            return myTable;
        }
    }
