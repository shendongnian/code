    var items = new List<dynamic>
    {
        new
        {
            Element1 = "Test Value",
            Id = 1
        },
        new
        {
            Element1 = "Test Value",
            Id = 1
        }
    };
    dataGridView1.DataSource = items;
    dataGridView1.Columns[1].DisplayIndex = 0;
    MessageBox.Show(dataGridView1[0, 0].Value.ToString());
