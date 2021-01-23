                _timer.Stop();
            string path = @"C:\testlog.log";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MYDB_Conn"].ConnectionString);
            string query = "SELECT RawImportEnabled, ImportDayTimeStamp from Settings";
            conn.Open(); // Dies here again.
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
