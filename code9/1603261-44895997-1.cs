        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //change code to get current row and check null, etc 
            var sels = dataGridView1.SelectedRows;
            if (sels == null || sels.Count == 0)
                return;
            DataGridViewRow selRow = sels[0];
            frmDialog dlg = new frmDialog(
                selRow.Cells[0].Value,
                selRow.Cells[1].Value);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                selRow.Cells[0].Value = dlg.Col1Value;
                selRow.Cells[1].Value = dlg.Col2Value;
                //...
            }
        }
    }
        public partial class frmDialog : Form
    {
        public object Col1Value;
        public object Col2Value;
        //...other properties
        public frmDialog()
        {
            InitializeComponent();
        }
        public frmDialog(object col1, object col2)
        {
            InitializeComponent();
            this.Col1Value = col1;
            this.Col2Value = col2;
            //...other properties
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
