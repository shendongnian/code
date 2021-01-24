    public partial class DataGridViewEx : DataGridView
    {
        public DataGridViewEx()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void SetSelectedRowCore(int rowIndex, bool selected)
        {
            this.SuspendLayout();
            base.SetSelectedRowCore(rowIndex, selected);
            int index = rowIndex;
            while (index < this.Rows.Count - 1 && this.Rows[index].Cells["BoxNo"].Value.ToString() == this.Rows[index + 1].Cells["BoxNo"].Value.ToString())
            {
                base.SetSelectedRowCore(index + 1, selected);
                index = index + 1;
            }
            index = rowIndex;
            while (index > 0 && this.Rows[index].Cells["BoxNo"].Value.ToString() == this.Rows[index - 1].Cells["BoxNo"].Value.ToString())
            {
                base.SetSelectedRowCore(index - 1, selected);
                index = index - 1;
            }
            this.ResumeLayout();
        }
    }
