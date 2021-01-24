    try
                {
                    dataGridView1.AutoGenerateColumns = false;
    
    
                    var items = new Dictionary<string, int>();
                    items.Add("Male", 1);
                    items.Add("FeMale", 2);
    
                    DataGridViewComboBoxColumn gender = new DataGridViewComboBoxColumn();
                    gender.DisplayMember = "Key";
                    gender.ValueMember = "Value";
                    gender.DataSource = new BindingSource(items, null);
    
    
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Gender", typeof(int));
                    dt.Rows.Add(new object[] { 1 });
                    dt.Rows.Add(new object[] { 2 });
                    dt.Rows.Add(new object[] { 2 });
                    dt.Rows.Add(new object[] { 2 });
                    dt.Rows.Add(new object[] { 1 });
                    dataGridView1.DataSource = dt;
    
                    gender.HeaderText = "Gender";
                    gender.DataPropertyName = "Gender";
                    dataGridView1.Columns.Add(gender);
                }
                catch (Exception ex)
                {
    
                    MessageBox.Show(ex.Message);
                }
