        public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            comboBox2.Items.Add(Employee.FullTimeEmployee);
            comboBox2.Items.Add(Employee.PartTimeEmployee);
            comboBox2.SelectedIndexChanged += ComboBox1OnSelectedIndexChanged;
            label1.Text = "Full text: ";
            label2.Text = "Integer value: ";
        }
        private void ComboBox1OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            label1.Text = "Full text: " + ((ComboBox) sender).SelectedItem;
            label2.Text = "Integer value: " + (int)(Employee)(((ComboBox)sender).SelectedItem);
        }
    }
    public enum Employee
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }
