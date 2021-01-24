            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colFileName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Value1",
                HeaderText = "Value 1",
                DataPropertyName = "Col1" 
            };
            DataGridViewCell cell2 = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colFileName2 = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell2,
                Name = "Value2",
                HeaderText = "Value 2",
                DataPropertyName = "Col2" 
            };
            dataGridView1.Columns.Add(colFileName);
            dataGridView1.Columns.Add(colFileName2);
            List<DataPopulate> list = new List<DataPopulate>();
            list.Add(new DataPopulate() { Col1 = "tes1", Col2 = "teste2"});
            list.Add(new DataPopulate() { Col1 = "tes1", Col2 = "teste2" });
            list.Add(new DataPopulate() { Col1 = "tes1", Col2 = "teste2" });
            var dataPopulateList = new BindingList<DataPopulate>(list); 
            dataGridView1.DataSource = dataPopulateList;
 
