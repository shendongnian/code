    private DataTable dt = new DataTable();
    private void BoatGPS_INTO_LIST()
    {
        SqlDataReader reader;
        string query = "select boat_id, boatGPS_DateTime, boatGPS_lat, boatGPS_lon from BoatGPS";
        using (SqlConnection sql = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"" + Environment.CurrentDirectory + "\\DB\\STS.mdf\"; Integrated Security = True; Connect Timeout = 30"))
        {
            sql.Open();
            using (reader = new SqlCommand(query, sql).ExecuteReader())
                dt.Load(reader);
            if(dt.Rows.Count > 0)
                // Here the syntax means: First row, fourth column
                MessageBox.Show(dt.Rows[0][3].ToString());
            else
                MessageBox.Show("Table is empty");
        }
    }
