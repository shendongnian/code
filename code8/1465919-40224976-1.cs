    public class DataGridViewUsers : DataGridView
    {
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int col = HitTest(e.X, e.Y).ColumnIndex;
            int row = HitTest(e.X, e.Y).RowIndex;
            if (col == -1 || row == -1)
            {
                base.OnMouseDown(e);
                return;
            }
            // Make sure we select the row we are clicking on
            if (!Rows[row].Selected)
                base.OnMouseDown(e);
            if (col == 0 && Rows[row].Selected)
            {
                DataGridViewCheckBoxCell cell = Rows[row].Cells[0] as DataGridViewCheckBoxCell;
                bool bIsSelection = cell != null && cell.Value != null && (bool)cell.Value;
                for (int i = 0; i < SelectedRows.Count; i++)
                {
                    SelectedRows[i].SetValues(!bIsSelection);
                }
            }
            else
            {
                // Process normally
                base.OnMouseDown(e);
            }
        }
    }
