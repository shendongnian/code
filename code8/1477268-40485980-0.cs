    void test()
    { 
    string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Database1.accdb;Persist Security Info=False;";
                OleDbConnection conn = new OleDbConnection(baglantiCumlesi);
                conn.Open();
                conn.Close();
    }
