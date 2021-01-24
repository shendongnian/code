    string[] stringy = { "A", "B", "C", "D", "E" };
    dataGridView1.Columns.Add("C1", "Header 1");
    dataGridView1.Columns["C1"].DataPropertyName = "Property1";
    dataGridView1.Columns.Add("C2", "Header 2");
    dataGridView1.DataSource = stringy.Select(x => new { Property1 = x }).ToList();
