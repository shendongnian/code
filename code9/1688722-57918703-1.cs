    class Program
    {
        const string cs =@"Data Source=<your server>;Initial Catalog=MyFsDb;Integrated Security=TRUE";
        static void Main(string[] args)
        {
            Save();
            Open();
        }
    
        private  static void Save()
        {
            var path = @"C:\Files1\testfile.txt";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader rdr = new BinaryReader(fs);
            byte[] fileData = rdr.ReadBytes((int)fs.Length);
            rdr.Close();
            fs.Close();
    
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string sql = "INSERT INTO MyFsTable VALUES (@fData, @fName, default)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@fData", SqlDbType.Image, fileData.Length).Value = fileData;
                cmd.Parameters.Add("@fName", SqlDbType.NVarChar).Value = "Some Name";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    
        private static void Open()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlTransaction txn = con.BeginTransaction();
                string sql = "SELECT fData.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT(), fName FROM MyFsTable";
                SqlCommand cmd = new SqlCommand(sql, con, txn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string filePath = rdr[0].ToString();
                    byte[] objContext = (byte[])rdr[1];
                    SqlFileStream sfs = new SqlFileStream(filePath, objContext, System.IO.FileAccess.Read);
                    byte[] buffer = new byte[(int)sfs.Length];
                    sfs.Read(buffer, 0, buffer.Length);
                    sfs.Close();
    
                    string fileContents = System.Text.Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(fileContents);
                }
    
                rdr.Close();
                txn.Commit();
                con.Close();
    
            }
        }
    }
