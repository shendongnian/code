    public partial class Form1 : Form
    {
        int loginAttemps = 0;
        public Form1()
        {
            InitializeComponent();
            txt_Password.PasswordChar = '*';
        }
        private void txt_login_Click(object sender, EventArgs e)
        {
            if (txt_USername.Text == "" && txt_Password.Text == "")
            {
                MessageBox.Show("Please enter your password and user_name");
                txt_USername.Clear();
                txt_Password.Clear();
            }
            else if (txt_USername.Text == "jondygonzales" && txt_Password.Text == "sharkwebcaster")
            { 
                loginAttempts = 0;
                MessageBox.Show("successfully log_in");
                Form1 f = new Form1();
                f.Show();
                Form2 main = new Form2();
                main.Show();
                this.Hide(); 
            }
            else
            {
                loginAttempts += 1;
            
                if(loginAttemps == 3)
                {
                    RecoveryForm recForm = new RecoveryForm(); // You need to use correct Form here.
                    recForm.Show();
                    this.Hide();
                }
            }
        }
    }
