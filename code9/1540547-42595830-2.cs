    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        UserInfo currentUser;
        private void btnOK_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var password = txtPassword.Text;
            currentUser = GetUser(userName, password);
            if (currentUser == null)
            {
                MessageBox.Show("invalid username | password");
                this.DialogResult = DialogResult.Cancel;
            }
            this.DialogResult = DialogResult.OK;
        }
        public UserInfo Login()
        {
            var dialogResult = this.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return null;
            return currentUser;
        }
        private UserInfo GetUser(string userName,string passwrod)
        {
            // you should check from where users located area(like db)
            if (userName.Equals("admin") && passwrod.Equals("test"))
            {
                return new UserInfo {
                    Id = 1,
                    LoginDate = DateTime.Now,
                    Roles = "Admin",
                    UserName ="admin"
                };
            }
            return null;
        }
    }
