    DataTable table = new DataTable();
    table.Columns.Add("First Name", typeof(string));
    table.Columns.Add("Last Name", typeof(string));
    table.Columns.Add("Age", typeof(int));
    
    if (File.Exists("file.txt"))
    {
        List<string[]> rows = File.ReadAllLines("file.txt").Select(x => x.Split(';')).ToList();
        foreach (var row in rows)
        {
            string fName = row[0];
            string lName = row[1];
            int age = -1;
            int.TryParse(row[2], out age);
    
            table.Rows.Add(fName,lName,age);
        }
    }
    dataGridView1.DataSource = table;
