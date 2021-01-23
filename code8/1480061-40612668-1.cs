     protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            icolumn = dataGridView1.CurrentCell.ColumnIndex;
            irow = dataGridView1.CurrentCell.RowIndex;
            int i = irow;
            if (keyData == Keys.Enter)
            {
                if (icolumn == dataGridView1.Columns.Count - 5)
                {
                       dataGridView1.CurrentCell = dataGridView1[icolumn + 2, irow];
                }
                else
                {
                    dataGridView1.CurrentCell = dataGridView1[icolumn - 2, irow + 1];
                }
               return true;
            }
            
           
            return base.ProcessCmdKey(ref msg, keyData);
        }
