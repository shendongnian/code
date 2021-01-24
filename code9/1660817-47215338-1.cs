    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var uc = new UserControl1();
            panel1.Controls.Add(uc);
        }
    }
