    public partial class NewAccountForm : Form
    {
        public NewAccountForm()
        {
            InitializeComponent();
        }
        Accounts account1;
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }
        private void btnlogout_Click(object sender, EventArgs e)
        {
            
            int interest = '0';
            char type = '0';
            double amount = '0' ;
            double balance = '0';
            
            
            switch (cboType.SelectedIndex)
            {
                case 0: type = '1'; break;
                case 1: type = '2'; break;
            }
            
            
            Saveing cust1 = new Saveing(interest, txtName.Text, txtContact.Text,
                txtpinCode.Text, type, amount,balance);
            Data.CSaveing.Add(cust1); //SList shows because its static if remove static will not appears
            account1.setname(txtName.Text);
            account1.setCode(txtpinCode.Text);
            account1.setcontact(txtContact.Text);
            
            
        }
        }
    }
