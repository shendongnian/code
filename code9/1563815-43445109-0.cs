    var listItem = ord.GET_ORDER_DETAILS(textBox1.Text);
    dataGridView1.DataSource = listItem;
    DataTable dt = new DataTable();
    dt.Columns.Add("Column1");
    dt.Columns.Add("Column2");
    foreach (var item in listItem)
    {
        dt.Rows.Add(item.Column1, item.Column2);
    }
