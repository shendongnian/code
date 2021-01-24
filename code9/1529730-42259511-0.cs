    using System;
    using System.Windows.Forms;
    using System.Configuration;
    using System.Reflection;
    
    namespace B4_HRM_System
    {
        public partial class SvrConfig : Form
        {
            public SvrConfig()
            {
                InitializeComponent();
            }
    
            private void btnsave_Click(object sender, EventArgs e)
            {
                try
    
                {
    
                    if (txtserver.Text == "")
                    {
                        MessageBox.Show("Please enter Server Name.", "7KProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtserver.Focus();
                        return;
                    }
    
    
    
                    if (txtdb.Text == "")
                    {
                        MessageBox.Show("Please enter Database.", "7KProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtdb.Focus();
                        return;
                    }
    
                    if (txtuser.Text == "")
                    {
                        MessageBox.Show("Please enter Username.", "7KProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtuser.Focus();
                        return;
                    }
    
    
    
                    if (txtpass.Text == "")
                    {
                        MessageBox.Show("Please enter Password.", "7KProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpass.Focus();
                        return;
                    }
    
                    string DBConn = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
                    DBConn = string.Format(DBConn, txtserver.Text, txtdb.Text, txtuser.Text, txtpass.Text);
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                    ConnectionStringsSection connSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                    connSection.ConnectionStrings["DBConn"].ConnectionString = DBConn;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("AppSettings");
                    MessageBox.Show("Successfully Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
    
                catch (Exception ex)
    
                {
    
                    MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
    
                }
            }
    
            private void btnexit_Click(object sender, EventArgs e)
            {
                this.Hide();
                b4login frmb4login = new b4login();
                frmb4login.Show();
           }
    
            }
    }
