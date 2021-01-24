             try
                {
                    dataGridView1.AutoGenerateColumns = false;
    
                    //source for combo box
                    var items = new Dictionary<string, int>();
                    items.Add("Male", 1);
                    items.Add("FeMale", 2);
    
                    //new combobox column for the GRID
                    DataGridViewComboBoxColumn gender = new DataGridViewComboBoxColumn();
                    gender.DisplayMember = "Key";
                    gender.ValueMember = "Value";
                    gender.DataSource = new BindingSource(items, null);
                    gender.HeaderText = "Gender";
                    gender.DataPropertyName = "Gender";
                    dataGridView1.Columns.Add(gender);
    
                    //Data for the GRID
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Gender", typeof(int));
                    dt.Rows.Add(new object[] { 1 });
                    dt.Rows.Add(new object[] { 2 });
                    dt.Rows.Add(new object[] { 2 });
                    dt.Rows.Add(new object[] { 2 });
                    dt.Rows.Add(new object[] { 1 });
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
    
                    MessageBox.Show(ex.Message);
                }
