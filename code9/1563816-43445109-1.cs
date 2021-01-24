    var dtResult = ord.GET_ORDER_DETAILS(textBox1.Text);
    dataGridView1.DataSource = dtResult;
    DataTable dt = new DataTable();
    dt.Columns.Add("Column1");
    dt.Columns.Add("Column2");
    foreach (var item in dtResult.Rows)
    {
        dt.Rows.Add(item["Column1"], item["Column2"]);
    }
