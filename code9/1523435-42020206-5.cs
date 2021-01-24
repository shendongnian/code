    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataGridView tmp = new DataGridView();
            GetVertElementasList getList = new GetVertElementasList();
            var TEST = getList.vertList(tmp);
            MessageBox.Show(TEST[5].p2.ToString());
            TestClass tmpClass = new TestClass();
        }
    }
