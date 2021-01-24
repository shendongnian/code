    public partial class EditForm : Form
    {
        DataRow row = null;
        DataView view;
        SqlDataAdapter adapter;
        public EditForm(SqlDataAdapter adapter, DataTable table, int rowId)
        {
            InitializeComponent();
            this.adapter = adapter;
            view = table.DefaultView;
            view.RowFilter = $"ID = {rowId}";
            if (view.Count == 0) throw new Exception("no such row");
            DataRowView dvr = view[0];
            row = dvr.Row;
            datebox.DataBindings.Add(new Binding("Value", view, "DATE"));
            stringbox.DataBindings.Add(new Binding("Text", view, "O_STRING"));
            this.FormClosing += EditForm_FormClosing;
        }
        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (row.RowState == DataRowState.Modified) adapter.Update(new DataRow[] { row });
        }
    }
