        private void Form1_Load(object sender, EventArgs e)
        {
            //THis will only be assigned when the Form is loaded.
            lbUsername.Text = "klik op de knop, dokus.";
        }
        private void btnMagic_Click(object sender, EventArgs e)
        {
            //On Every button click this will be executed.
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            lbUsername.Text = "Username: Hallo," + userName;
        }
