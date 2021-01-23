    private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
    {
        loadBoxes();
    }
    void loadBoxes()
    {
        List<DataBox> boxes = new List<DataBox>();
        for (int i = 0; i < dataGridView1.RowCount; i++)
            boxes.Add(new DataBox(dataGridView1, i));
        flowLayoutPanel1.Controls.Clear();
        flowLayoutPanel1.Controls.AddRange(boxes.ToArray());
    }
