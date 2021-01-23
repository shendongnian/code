    public bool AreFilesInUse()
    {
        var FilesInUse = new List<string>();
        con = new SqlConnection(cs.DBConn);
        con.Open();
        var sql = "SELECT FileName FROM SentRecycle WHERE FileName = @file";
        cmd = new SqlCommand(sql);
        cmd.Parameters.Add("@file", SqlDbType.NVarChar);
        cmd.Connection = con;
        foreach (DataGridViewRow dtrow2 in frm.dataGridView2.Rows)
        {
            var file = dtrow2.Cells[2].Value.ToString();
            cmd.Parameters["@file"].Value = file;
            // frm.ShowDataGridView(); // does not seem useful here, maybe before the loop
            var reader = cmd.ExecuteReader();
            if (reader.Read())
                FilesInUse.Add(file);  // remember file name
            reader.Close();
        }
        bool foundAny = FilesInUse.Count > 0;
        if (foundAny)
        {
            var files = string.Join("\r\n", FilesInUse);
            MessageBox.Show("The following files are already in use:\r\n" + files, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        con.Close();
        return foundAny;
    }
}
