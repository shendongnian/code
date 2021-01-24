    public partial class frmMain : Form
    {    
        public frmMain()
        {
            InitializeComponent();
        }
    
        private void btnCalc_Click(object sender, EventArgs e)
        {
            // the 'this' is optional so you can remove it
            txtC.Text = this.CalcHypotenuse(double.Parse(txtA.Text), double.Parse(txtB.Text));
        }
    
        public string CalcHypotenuse(double sideA, double sideB)
        {
            double hypotenuse = Math.Sqrt((sideA * sideA) + (sideB * sideB));
            string hypotenuseString = hypotenuse.ToString();
            return hypotenuseString;
        }
    
    }
