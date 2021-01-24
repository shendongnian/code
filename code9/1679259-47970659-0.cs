    var connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\UNI WORK\7th Semester\Visual Programming\Database31.accdb; " + "User id = admin; " + "Password = ";
    using (var oledbCnn = new OleDbConnection(connectionString))
    {
        oledbCnn.Open();
        var cmd = new OleDbCommand("SELECT * FROM Attendancerecord", oledbCnn);
        OleDbDataAdapter add = new OleDbDataAdapter(cmd);
        DataTable dt = new DataTable();
        add.Fill(dt);
        dataGridView1.DataSource = dt;
        oledbCnn.Close();
    }
