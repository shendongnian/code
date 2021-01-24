    DataTable stuffToDisplay = new DataTable();
    using (var conn = new OleDbConnection { ConnectionString = DataBase.ConnectionString() })
    {
        conn.Open();
    
        using(var command = new OleDbCommand("SELECT [ID],[ClassName] FROM Class WHERE TeacherID = @TeacherID", conn))
        {
            command.Parameters.AddWithValue("@TeacherID", Properties.Settings.Default.UserID);
            using(var adapter = new OleDbDataAdapter(command))
            {
                adapter.Fill(stuffToDisplay);
            }
        }
    }
    
    _ClassGrid.ItemsSource = stuffToDisplay;
