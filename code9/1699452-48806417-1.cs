    public class MyDataGridView : DataGridView
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyData == (Keys.A | Keys.Control))
            {
                MessageBox.Show("Handled");
                return true; 
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
