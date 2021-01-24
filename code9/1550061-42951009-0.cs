    private void dgFolien_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
        DataRowView drv = e.Row.DataContext as DataRowView;
        if (drv != null)
        {
            using (OleDbConnection conn = new OleDbConnection("yourConnectionString..."))
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.Parameters.Add(new OleDbParameter("@var1", drv["Hersteller"].ToString()));
                cmd.Parameters.Add(new OleDbParameter("@var2", drv["Serie"].ToString()));
                cmd.Parameters.Add(new OleDbParameter("@var3", drv["Farbe"].ToString()));
                cmd.Parameters.Add(new OleDbParameter("@var4", drv["EK-Preis"].ToString()));
                cmd.CommandText = "UPDATE Folien SET Hersteller=@var1, Serie=@var2, Farbe=@var3 WHERE [EK-Preis] = @var4";
                cmd.ExecuteNonQuery();
            }
        }
    }
