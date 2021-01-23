    public class MyDataGridView : DataGridView
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool enterKeyDetected = keyData == Keys.Enter;
            bool isLastRow = this.CurrentCell.RowIndex == this.RowCount - 1;
            if (enterKeyDetected && isLastRow)
            {
                Console.WriteLine("Enter detected on {0},{1}", this.CurrentCell.RowIndex, this.CurrentCell.ColumnIndex);
                // Add the new row.
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
