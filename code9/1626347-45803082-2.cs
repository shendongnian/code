    var dtCustomers = new DataTable();
    var adapter = new OleDbDataAdapter("SELECT * FROM Devices WHERE replace([Serial Number], " ", "")='" + textBox1.Text.Relpace(" ","") + "'", conn);
    adapter.Fill(dtCustomers);
    dataGridView1.DataSource = dtCustomers;
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        row.Cells[0].Style.ForeColor = Color.Blue;
        row.Cells[28].Style.ForeColor = Color.Red;
    }
