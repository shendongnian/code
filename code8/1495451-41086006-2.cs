    class CustomDataGridview : DataGridView
    {
        protected override bool ProcessDialogKey(Keys keyData) // Fired when key is press in edit mode
        {
            if (keyData == Keys.Enter)
            {
                MoveToRightCell();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e) // Fired when key is press in non-edit mode
        {
            if (e.KeyData == Keys.Enter)
            {
                MoveToRightCell();
                e.Handled = true;
                return;
            }
            base.OnKeyDown(e);
        }
        private void MoveToRightCell()
        {
            int col = this.CurrentCell.ColumnIndex;
            int row = this.CurrentCell.RowIndex;
            if (col < this.ColumnCount - 1)
            {
                col++;
            }
            else
            {
                col = 0;
                row++;
            }
            if (row == this.RowCount)
            {
                this.Rows.Add();
            }
            this.CurrentCell = this[col, row];
        }
    }
