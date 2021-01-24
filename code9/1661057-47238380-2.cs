    public partial class MyEditorForm<T> : Form
    {
        public MyEditorForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public BindingList<T> List
        {
            get
            {
                return (BindingList<T>)dataGridView1.DataSource;
            }
            set
            {
                if (value == null)
                    value = new BindingList<T>();
                dataGridView1.DataSource = new BindingList<T>(value);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    } 
