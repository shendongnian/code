    private void button1_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = ord.GET_ORDER_DETAILS(textBox1.Text);
        DataTable dt = new DataTable();
        foreach(var r in dataGridView1.Rows)
        {
            dt.Rows.Add(r.Cells[0].Value, r.Cells[1]);
        }
    }
