    var dt = new DataTable(); 
    dt.Columns.Add("C1", typeof(bool));
    dt.Columns.Add("C2", typeof(int));
    dt.Columns.Add("C3", typeof(string));
    dt.Columns.Add("C4", typeof(bool));
    dt.Rows.Add(true, 1, "test", false);
    this.dataGridView1.DataSource = dt;
    this.dataGridView1.Columns.Cast<DataGridViewColumn>().ToList()
        .ForEach(x =>
        {
            if (x.ValueType == typeof(bool))
            {
                var index = x.Index;
                this.dataGridView1.Columns.RemoveAt(index);
                var c = new DataGridViewComboBoxColumn();
                c.DataSource = new List<bool>() { true, false }.Select(b => new
                {
                    Value = b,
                    Name = b ? "Yes" : "No" /*or simply b.ToString*/
                }).ToList();
                c.ValueMember = "Value";
                c.DisplayMember = "Name";
                c.DataPropertyName = x.DataPropertyName;
                c.HeaderText = x.HeaderText;
                this.dataGridView1.Columns.Insert(index, c);
            }
        });
