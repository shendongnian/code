    // re-usable variable to avoid typos...
    private const string _schedule_Id_TableName = "schedule_ids";
    private void StartMenu_Load(object sender, EventArgs e)
    {
        this.CenterToScreen();
        if (!File.Exists("schedules.db"))
        {
            SQLiteConnection.CreateFile("schedules.db");
            MessageBox.Show("Created schedules.db");
        }
        SQLCon = CreateSQLiteConnection();
        SQLCon.Open();
        using (SQLiteCommand cmd = new SQLiteCommand(string.Format("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{0}'", _schedule_Id_TableName), SQLCon))
        {
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    using (SQLiteCommand loadSchedules = new SQLiteCommand(string.Format("SELECT name FROM {0}", _schedule_Id_TableName), SQLCon))
                    {
                        reader.Close();
                        using (SQLiteDataReader reader1 = loadSchedules.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                MessageBox.Show("?");
                                ScheduleList.Items.Add((string)reader1[0]);
                            }
                            MessageBox.Show("$");
                        }
                    }
                }
                else
                {
                    reader.Close();
                    // Only create the table if it doesn't already exists...
                    using (SQLiteCommand createTable = new SQLiteCommand(string.Format("CREATE TABLE IF NOT EXISTS {0}(name nvarchar(45), schedule_id int)", _schedule_Id_TableName), SQLCon))
                    {
                        createTable.ExecuteNonQuery();
                    }
                }
            }
        }
    }
    private SQLiteConnection CreateSQLiteConnection()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory;
        //path = path.Replace(@"bin\Debug\", "");
        SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
        builder.FailIfMissing = true;
        builder.DataSource = Path.Combine(path, "schedules.db");
        return new SQLiteConnection(builder.ConnectionString);
    }
