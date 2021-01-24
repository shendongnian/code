    private void Button1_Click(object sender, EventArgs e)
	{
        if (openFile.ShowDialog() == DialogResult.OK)
        {
            List<string[]> rows = File.ReadLines(openFile.FileName).Select(x => x.Split(',')).ToList();
            DataTable dt = new DataTable();
            List<string> headerNames = rows[0].ToList();
            foreach (var headers in rows[0])
            {
                dt.Columns.Add(headers);
            }
            foreach (var x in rows.Skip(1).OrderBy(r => r.First()))  //sort based on first column of each row
            {
                if (x.SequenceEqual(headerNames))   //linq to check if 2 lists are have the same elements (perfect for strings)
                    continue;     //skip the row with repeated headers
                if (x.All(val => string.IsNullOrWhiteSpace(val))) //if all columns of the row are whitespace / empty, skip this row
                    continue;
                dt.Rows.Add(x);
            }
            dataGridView1.DataSource = dt;
        }
    }
