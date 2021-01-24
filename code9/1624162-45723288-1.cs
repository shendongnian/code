    static DataTable GetTable()
    {
       // DataTable with 4 columns
       DataTable table = new DataTable("Students");
       table.Columns.Add("Id", typeof(int));
       table.Columns.Add("Name", typeof(string));
       table.Columns.Add("Teacher", typeof(string));
       table.Columns.Add("Birthday", typeof(DateTime));
    
       // Add 5 rows
       table.Rows.Add(1, "John", "Mr. Charles", DateTime.Parse("2001-01-01"));
       table.Rows.Add(2, "Lennard", "Mr. Charles", DateTime.Parse("2002-02-02"));
       table.Rows.Add(3, "John", "Lady Graham", DateTime.Parse("2003-03-03"));
       table.Rows.Add(4, "Penny", "Mr. Charles", DateTime.Parse("2004-04-04"));
       table.Rows.Add(5, "Sheldon", "Sir Winster", DateTime.Parse("2005-05-05"));
       return table;
    }
