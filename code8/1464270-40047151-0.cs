    _timer.Stop();
            string path = @"C:\testlog.log";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MYDB_Conn"].ConnectionString);
            conn.Open(); // sholud be here
            
            string query = "SELECT RawImportEnabled, ImportDayTimeStamp from Settings";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
