        private void btn_AddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                // Username en wachtwoord in variabelen zetten.
                string userName = generator(8);
                string password = generator(8);
                // Juiste OU pad aangeven. Afhankelijk van geselecteerde richting.
                string ouString = "OU = " + cmb_Study.Text;
                string LDAPstring = "LDAP://" + ouString + ", DC=DR, DC=GUI";
                DirectoryEntry dirEntry = new DirectoryEntry(LDAPstring);
                // User aanmaken.
                string userString = "CN = " + userName;
                DirectoryEntry newUser = dirEntry.Children.Add(userString, "user");
                newUser.CommitChanges();
                newUser.Properties["userPrincipalName"].Add(userName + "@DR.GUI");
                newUser.Properties["sAMAccountName"].Value = userName;
                newUser.Invoke("SetPassword", new object[] {password});
                newUser.Properties["initials"].Value = txt_Initials;
                newUser.Properties["Given-Name"].Value = txt_FName;
                newUser.Properties["sn"].Value = txt_LName;
                newUser.Properties["mail"].Value = txt_Mail;
                newUser.Properties["mobile"].Value = txt_Mobile;
                newUser.Properties["telephoneNumber"].Value = txt_Telephone;
                newUser.Properties["streetAddress"].Value = txt_Street + " " + txt_Number;
                newUser.Properties["postalCode"].Value = txt_PostalCode;
                newUser.Close();
                dirEntry.Close();
                newUser.Dispose();
                dirEntry.Dispose();
                MessageBox.Show("User has been succesfully added");
