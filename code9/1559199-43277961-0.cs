        public static void WriteByteArrayToID(int aID, byte[] aFile)
        {
            conn.Open();
            dbCommand = new OleDbCommand("UPDATE Belege SET Datei = @file WHERE(ID = @ID)", conn);
            string tmp = Convert.ToBase64String(aFile);
            dbCommand.Parameters.Add("@file", OleDbType.VarChar).Value = tmp;
            dbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = aID;
            dbDataAdapter = new OleDbDataAdapter(dbCommand);
            dbCommand.ExecuteNonQuery();
            conn.Close();
        }
        public static DataTable GetFileByteArrayByID(int aID)
        {
            conn.Open();
            dbCommand = new OleDbCommand("SELECT Datei FROM Belege WHERE (ID = @ID)", conn);
            dbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = aID;
            dbDataAdapter = new OleDbDataAdapter(dbCommand);
            DataTable resultDataTable = new DataTable();
            dbDataAdapter.Fill(resultDataTable);
            conn.Close();
            return resultDataTable;
        } 
            //-----------------------------------------------------------------------------------------------------------------
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\user\Music\1.pdf");
            
            AccessConnector.WriteByteArrayToID(122, bytes);
            DataTable table = AccessConnector.GetFileByteArrayByID(122);
            string file = table.Rows[0][0] as string;
            System.IO.File.WriteAllBytes(@"C:\Users\user\Documents\Dokumente\a.pdf", Convert.FromBase64String(file));
            //-----------------------------------------------------------------------------------------------------------------
