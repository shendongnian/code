    if (File.Exists("file.txt"))
    {
        List<string[]> rows = File.ReadAllLines("file.txt").Select(x => x.Split(';')).ToList();
    
        DataTable table = new DataTable();
        table.Columns.Add(rows[0][0], typeof(string));
        table.Columns.Add(rows[0][1], typeof(string));
        table.Columns.Add(rows[0][2], typeof(int));
    
    
        foreach (var row in rows.Skip(1))
        {
            string fName = row[0];
            string lName = row[1];
            int age = -1;
            int.TryParse(row[2], out age);
    
            table.Rows.Add(fName, lName, age);
        }
        dataGridView1.DataSource = table;
    }
