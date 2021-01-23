    public class CopyDataGridView : DataGridView
    {
        public bool ProcessShiftCopy { get; set; }
    
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ProcessShiftCopy = keyData == (Keys.Control | Keys.Shift | Keys.C);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
