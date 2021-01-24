    public class EditableDataGridView : DataGridView
    {
        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);
            if (key == Keys.Up || key == Keys.Down )
            {
                return false; 
            }
            return base.ProcessDialogKey(keyData);
        }
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down )
            {
                return false;
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
