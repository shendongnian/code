    public partial class frmTest : Form
    {
        private string _value { get; set; }
        public frmTest()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            this._value = radioButton.Text; // Assign the radio button text as value Ex: AAA
        }
        public string GetValue()
        {
            return this._value;
        }
    }
