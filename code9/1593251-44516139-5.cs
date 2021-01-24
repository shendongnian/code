    private void Button1_Click(object sender, EventArgs e)
    {
        //if open successfully, then apply streamReader to it
        if (openFile.ShowDialog() == DialogResult.OK)
        {
            List<string[]> rows = System.IO.File.ReadAllLines(openFile.FileName).Select(x => x.Split(',')).ToList();
            System.Data.DataTable dt = new System.Data.DataTable();
            List<string> headerNames = rows[0].ToList();
            foreach (var header in headerNames)
            {
                dt.Columns.Add(headers);
            }
            foreach (var x in rows.Skip(1))
            {
                if (x.SequenceEqual(headerNames))   //linq to check if 2 lists are have the same elements (perfect for strings)
                    continue;     //skip the row with repeated headers
                dt.Rows.Add(x);
            }
            dgv.DataSource = dt;
        }
    }
