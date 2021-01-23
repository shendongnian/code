    public partial class Form1 : Form
    {
        List<object[]> people = new List<object[]>();
        public Form1()
        {
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var person = new object[3];
            person[0] = txtFirstName.Text;
            person[1] = txtLastName.Text;
            person[2] = txtBirthday.Text;
            people.Add(person);
            txtPeople.Text = string.Empty;
            for (var i=0;i<people.Count;i++)
            {
                txtPeople.Text += string.Format("First name:\t{0}", people[i][0].ToString()) + Environment.NewLine;
                txtPeople.Text += string.Format("Last name:\t{0}", people[i][1].ToString()) + Environment.NewLine;
                txtPeople.Text += string.Format("Birthday:\t\t{0}", people[i][2].ToString()) + Environment.NewLine + Environment.NewLine;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "FirstName" + people.Count();
            txtLastName.Text = "LastName" + people.Count();
            txtBirthday.Text = "Birthday" + people.Count();
        }
    }
