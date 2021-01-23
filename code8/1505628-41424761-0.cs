    String sConnectionString = "Data Source=mydb.db3;Version=3;Password=123456;";
    private void longitudinalProfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        saveProject(iProjectID);
        computeArea(iProjectID);
    }
    saveProject(iProjectID)
    {
        SQLiteCommand sqlite_cmd;
        SQLiteCommand sqlite_cmd_PostWork;
        SQLiteCommand sqlite_cmd_Design;
        using (sqlite_conn = new SQLiteConnection(sConnectionString))
        {
            sqlite_cmd.CommandText = "Delete from prework where pid = " + iProjectID + ";";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "Insert into prework (pid, chainage, date) values (" + iProjectID + "," + fChainagePostwork + ",'" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "');";
            sqlite_cmd.ExecuteNonQuery();
        }
    }
    computeArea(iProjectID)
    {
        SQLiteCommand sqlite_cmd;
        SQLiteCommand sqlite_cmd_PostWork;
        SQLiteCommand sqlite_cmd_Design;
        using (sqlite_conn = new SQLiteConnection(sConnectionString))
        {
            sqlite_cmd.CommandText = "Delete from postwork where pid = " + iProjectID + ";";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "Insert into postwork (pid, chainage, date) values (" + iProjectID + "," + fChainagePostwork + ",'" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "');";
            sqlite_cmd.ExecuteNonQuery();
        }
    }
