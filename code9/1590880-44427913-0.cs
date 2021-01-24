    //dialog form
    public partial class frmDialogcs : Form
    {
        public string selectedString;
        //keep default constructor or not is fine
        public frmDialogcs()
        {
            InitializeComponent();
        }
        public frmDialogcs(IList<string> lst)
        {
            InitializeComponent();
            for (int i = 0; i < lst.Count; i++)
            {
                RadioButton rdb = new RadioButton();
                rdb.Text = lst[i];
                rdb.Size = new Size(100, 30);
                this.Controls.Add(rdb);
                rdb.Location = new Point(20, 20 + 35 * i);
                rdb.CheckedChanged += (s, ee) =>
                {
                    var r = s as RadioButton;
                    if (r.Checked)
                        this.selectedString = r.Text;
                };
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
        //in main form
        private void button1_Click(object sender, EventArgs e)
        {
            var lst = new List<string>() { "a", "b", "c" };
            frmDialogcs dlg = new frmDialogcs(lst);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string selected = dlg.selectedString;
                MessageBox.Show(selected);
            }
        }
