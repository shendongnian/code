    public partial class Form2 : Form
    {
        string rec;
        public Form2(string rec)
        {
            InitializeComponent();
            this.rec = rec;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = rec;
        }
    }
