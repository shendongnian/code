    private DataTable myTable()
        {
            OleDbConnection conn = new OleDbConnection("Provider=VFPOLEDB.1;Data Source=c:\\Data\\;Extended Properties=dBASE IV;User ID=;Password=;");
            conn.Open();
            string querry = "SELECT * FROM d:\\data\\Earthquakes1970";
            OleDbCommand cmd = new OleDbCommand(querry, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            return dt;
        }
