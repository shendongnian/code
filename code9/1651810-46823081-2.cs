    private void button1_Click(object sender, EventArgs e)
    {
        Task.Run(() =>
        {
            //Define DataTable
            var table = new DataTable();
            table.Columns.Add("Column 1", typeof(int));
    
            //Fill DataTable
            for (int i = 0; i < 100000; i++)
                table.Rows.Add(new object[] { i });
    
            //Set DataSource
            dataGridView1.Invoke(new Action(() => { dataGridView1.DataSource = table; }));
        });
    }
