    static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Server=.\YourServer;Database=ValidDatabase;User Id=User;Password = Password;");
            SqlCommand command = con.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM OPENROWSET(BULK N'C:\MSSQL\Backup\DbBackup.bak', SINGLE_BLOB) AS Contents";
            con.Open();
            command.BeginExecuteReader(callback, command,
                    CommandBehavior.CloseConnection);
            Console.ReadLine();
        }
        private static void callback(IAsyncResult ar)
        {
            SqlCommand cmd = (SqlCommand)ar.AsyncState;
            SqlDataReader reader = cmd.EndExecuteReader(ar);
            bool res = reader.Read();
            using (BinaryReader br = new BinaryReader(reader.GetStream(0)))
            {
                FileStream fs = File.Create(@"c:\temp\RemoteDbBackupbak.bak");
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    int index = 0;
                    byte[] buffer = new byte[8192];
                    while ((index = br.Read(buffer, 0, 8192)) > 0)
                    {
                        fs.Write(buffer, 0, index);
                    }
                }
            }
        }
