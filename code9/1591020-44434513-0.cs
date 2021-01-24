    object[] data = { "Test", 9, "Test Two", "Test Three" };
    
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("No", "Number");
                dataGridView1.Columns.Add("Desc", "Description1");
                dataGridView1.Columns.Add("Desc1", "Description2");
    
                for (int i = 0; i < 10; i++)
                    dataGridView1.Rows.Add(data);
