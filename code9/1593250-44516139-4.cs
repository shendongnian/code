    private void Button1_Click(object sender, EventArgs e)
    {
        //if open successfully, then apply streamReader to it
        if (openFile.ShowDialog() == DialogResult.OK)
        {
            List<string[]> rows = System.IO.File.ReadAllLines(openFile.FileName).Select(x => x.Split(',')).ToList();
            System.Data.DataTable dt = new System.Data.DataTable();
            foreach (var headers in rows[0])
            {
                dt.Columns.Add(headers);
            }
            foreach (var x in rows.Skip(1))
            {
                dt.Rows.Add(x);
            }
            dgv.DataSource = dt;
        }
    }
