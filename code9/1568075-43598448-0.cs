    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            //Do whatever you need to do here. I'm simple setting some text based off
            //the name of the checked radio button.
    
            System.Windows.Forms.RadioButton rb = (sender as System.Windows.Forms.RadioButton);
            textBox1.Text = $"{rb.Name} is checked!";
        }
    }
