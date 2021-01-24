    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDepartmentName.Text))
            {
                int id = 0;
                Operations ops = new Operations();
                if (ops.InsertDepartment(txtDepartmentName.Text, ref id))
                {
                    MessageBox.Show($"Id for '{txtDepartmentName.Text}' is {id}");
                }
                else
                {
                    MessageBox.Show($"Department '{txtDepartmentName.Text}' is already in the database table");
                }
            }
            else
            {
                MessageBox.Show("Please enter a department name");
            }
        }
    }
