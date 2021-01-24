        private void moveUp()
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int rowCount = dataGridView1.Rows.Count;
                    int index = dataGridView1.SelectedCells[0].OwningRow.Index;
                    if (index == 0)
                    {
                        return;
                    }
                    var temp = listApp[index];
                    var temp2 = listApp[index - 1];
                    listApp.Remove(temp);
                    listApp.Remove(temp2);
                    listApp.Insert(index-1, temp);
                    listApp.Insert(index, temp2);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = listApp;
                    dataGridView1.SelectedCells[0].Selected = false;                    
                    dataGridView1.Rows[index-1].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1[1, index - 1];
                }
            }
        }
