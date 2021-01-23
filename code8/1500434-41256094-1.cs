	public partial class frmRealEstateCollections : Form
    {
		private List<decimal> _decimalValues = new List<decimal>();
        public frmRealEstateCollections()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // declare variables
            decimal decPropertyValue = 0m;
            // Data Validation
            try
            {
                decPropertyValue = Convert.ToDecimal(txtPropertyValue.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Input Numeric value",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                txtPropertyValue.Focus();
            }
            // call list
			_decimalValues.Add(decPropertyValue);		
			
            lstEnteredValues.Items.Add(decPropertyValue.ToString("C2"));          
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Declared List/Variables to call list Method
            decimal decAverage = 0m;
            // Call List
            decAverage = _decimalValues.Average();
            lstAnalysis.Items.Add(decAverage);
        }
    }
