        int rowCount = 5;
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("id", typeof(String)));
        table.Columns.Add(new DataColumn("encrypted", typeof(String)));
        table.Columns.Add(new DataColumn("decrypted", typeof(String)));
        //Write test encrypted data to data table
        for(int i = 0; i < rowCount; i++) 
        {
            string clearText = "test" + i.ToString();
            string cipherText = Encrypt(clearText);
            table.Rows.Add(new object[] {i.ToString(), cipherText, ""});
        }
        //Decrypt each item, and assign result to decrypted column
        foreach (DataRow row in table.Rows) 
        {
            row["decrypted"] = Decrypt(row["encrypted"].ToString());
        }
