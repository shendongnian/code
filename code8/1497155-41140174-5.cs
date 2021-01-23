    private bool _automatedRowChange;
    
            private void Initialize()
            {
                List<Dummy> dummies = new List<Dummy> { new Dummy { Id = 1, Text = "Test1" }, new Dummy { Id = 2, Text = "Test2" } };
                bindingSource1.DataSource = dummies;
                dataGridView1.DataSource = bindingSource1;
    
                //So the first row isn't focused but the bindingSource Current Property still holds the first entry
                //That's why it won't fire currentChange even if you click the first row. Just looks better for the user i guess
                dataGridView1.ClearSelection();
    
                bindingSource1.CurrentChanged += BindingSource1_CurrentChanged;
                dataGridView1.CellClick += DataGridView1_CellClick;
            }
    
            private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                var clickedRow = dataGridView1.Rows[e.RowIndex].DataBoundItem as Dummy;
                var currentRow = bindingSource1.Current as Dummy;
    
                if (clickedRow != null &&
                    currentRow != null &&
                    clickedRow.Equals(currentRow))
                {
                    _automatedRowChange = true;
                    bindingSource1.MoveNext();
    
                    _automatedRowChange = false; //MovePrevious is based on the click and should load the dataSource2
                    bindingSource1.MovePrevious();
                }
            }
    
            private void BindingSource1_CurrentChanged(object sender, EventArgs e)
            {
                if (!_automatedRowChange) //Check if you jump to next item automatically so you don't load dataSource2 in this case
                {
                    //Set the second DataSource based on selectedRow
                }
            }
