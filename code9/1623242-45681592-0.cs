    public partial class Form1 : Form
    {
        private string _Title = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_Title.Items.Add("Cat");
            cmb_Title.Items.Add("Dog");
            cmb_Title.Items.Add("Bear");
        }
        public string Title
        {
            set
            {
                _Title = value;
                cmb_Title.SelectedIndex = cmb_Title.FindStringExact(value);
            }
            get
            {
                return _Title;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show(this);
        }
    }
        public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            cmb_Title.Items.Add("Cat");
            cmb_Title.Items.Add("Dog");
            cmb_Title.Items.Add("Bear");
        }
        private void cmb_Title_SelectedIndexChanged(object sender, EventArgs e)
        {
            var f1 = this.Owner as Form1;
            f1.Title = cmb_Title.Text;
        }
    }
