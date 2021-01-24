    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Child Form: Validated!");
        }
        private void Form2_Closing(object sender, FormClosingEventArgs e)
        {
            if (!Validate())
                //Write your code that will execute if your form is not validated
        }
    }
