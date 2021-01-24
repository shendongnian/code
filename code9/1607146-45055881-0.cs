    public static class ExtensionTest
    {
        public static int ToComboNumber(this string input)
        {
            if (input == "Yes")
                return 1;
            else
                return 0;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number = comboBox1.Text.ToComboNumber();
            MessageBox.Show(number.ToString());
        }        
    }
