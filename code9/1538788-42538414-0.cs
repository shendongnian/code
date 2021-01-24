        OleDbConnection conn = new OleDbConnection(Dts.Connections[".\\sql2016.SSISAuditDB"].ConnectionString);
        using (conn)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT 1", conn);
            int val = (int)cmd.ExecuteScalar();
            MessageBox.Show(val.ToString());
        }
