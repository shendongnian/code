    public DataTable getData(string sqlCommand)
    {
        DataTable dt = new DataTable();
        using (var con = new SQLiteConnection { ConnectionString = "your connection string" })
        {
           using (var command = new SQLiteCommand { Connection = con })
           {
               if (con.State == ConnectionState.Open)
                   con.Close();
               con.Open();
               command.CommandText = sqlCommand;
               dt.Load(command.ExecuteReader());
           }
           return dt;
        }
     }
    //Call to load your Data
    public void loadData()
    {
       this.DatagridView.DataSource = getData("Command string here");
    }
