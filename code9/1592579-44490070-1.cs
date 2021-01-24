    private const string _connectionString = @"Data Source = (LocalDB) <snipped..>";
    private void button1_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO Table (Id,name) Values (34, 'John')";
        int rowsInserted;
        using (var db = new SqlConnection(_connectionString))
        {
            rowsInserted = db.Execute(query);
        }
 
        if (rowsInserted != 1)
        {
            // Log/Handle the fact that you failed to insert 1 record;
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        IList<Foo> foos;
        using (var db = new SqlConnection(_connectionString))
        {
            const string query = "SELECT * FROM Table";
             // This will always return a list. It's empty or has items in it.
            foos = db.Query<Foo>(query).ToList();
        }
        foreach(var foo in foos)
        {
            MessageBox.Show($"{foo.Id} - {foo.Name}");
        }
    }
