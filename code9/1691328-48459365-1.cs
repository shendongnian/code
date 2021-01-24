    public partial class Form2 : Form
    {
        private int my_number;
        public Form2(int input)
        {
            InitializeComponent();
            txtName.Enabled = false;
            txtPrzNo.Enabled = false;
            txtTableNo.Enabled = false;
            txtYear.Enabled = false;
            my_number = input;
        }
    }    
