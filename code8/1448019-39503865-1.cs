     public DataTable ReadCSV(String FilePath, Boolean IsHeader)
        {
            string strConn = null;
            string folderpath = null;
            try
            {
                folderpath = FilePath.Substring(0, FilePath.LastIndexOf("\\") + 1);
                string FileName = Path.GetFileName(FilePath);               
                if (IsHeader == true)
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + folderpath + ";" + "Extended Properties=\"text;HDR=YES\"";
                }
                else
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + folderpath + ";" + "Extended Properties=\"text;HDR=NO\"";
                }
                OleDbConnection Conn = new OleDbConnection();
                Conn.ConnectionString = strConn;
                Conn.Open();
                string s1 = "select * from [" + FileName + "]";
                OleDbDataAdapter da1 = new OleDbDataAdapter(s1, Conn);
                DataSet dtall = new DataSet();
                da1.Fill(dtall);
                Conn.Close();
                return dtall.Tables[0].Copy();
            }
            catch (Exception ex)
            {
                Exception excep = new Exception("CSV : " + ex.Message);
                throw excep;
            }
        }
