    private void Button1_Click(object sender, EventArgs e)
    {
        //if open successfully, then apply streamReader to it
        if (openFile.ShowDialog() == DialogResult.OK)
        {
            List<string[]> rows = System.IO.File.ReadAllLines(openFile.FileName).Select(x => x.Split(',')).ToList();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            rows.ForEach(x => {
                dt.Rows.Add(x);
            });
            dgv.DataSource = dt;
        }
    }
