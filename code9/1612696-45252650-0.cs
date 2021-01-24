    public partial class MainForm
    {
    
        private ChildForm _childForm;
        
        public void ShowChildForm()
        {
            _childForm = new ChildForm();
            _childForm.Show();
        }
        
        public void ReadRowCount()
        {
            if (_childForm != null)
            {
                // Reading variable from child form
                int rowCount = _childForm.RowCount;
            }
        }
    }
    public partial class ChildForm
    {
        public int RowCount { get; private set; }
    }
