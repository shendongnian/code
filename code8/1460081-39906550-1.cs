    private void Form1_Load(object sender, EventArgs e)
            {
                dataGridView1.Columns.Add("test1", "test1");
                DataGridViewComboBoxColumn testCol = new DataGridViewComboBoxColumn();
                testCol.HeaderText = "comboValues";
                dataGridView1.Columns.Add(testCol);
                dataGridView1.Columns.Add("test2", "test1");
                List<Item> items = new List<Item>();
                items.Add(new Item() { Name = "One", Id = 1 });
                items.Add(new Item() { Name = "Two", Id = 2 }); // created two Items 
                var cbo = dataGridView1.Columns[1] as DataGridViewComboBoxColumn; // index of 1 is the comboboxColumn
                cbo.DataSource = items; // setting datasource 
                cbo.ValueMember = "Id";
                cbo.DisplayMember = "Name";
                dataGridView1.Rows.Add("", items[1].Id, "test1");
                dataGridView1.Rows.Add("", items[0].Id, "test2");
                dataGridView1.Rows.Add("", items[1].Id, "test3"); // and test rows
            }
