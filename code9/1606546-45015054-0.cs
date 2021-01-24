        private void ConfigSaveButton_Click_Click(object sender, EventArgs e)
        {
            if (UsernameTextBoxes.TrueForAll(t => t.Text.Length > 0) &&
              PasswordTextboxes.TrueForAll(t => t.Text.Length > 0))
            {
                DialogResult result = MessageBox.Show("Changes saved! ", "Information", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    EnvironmentConfigManager configmgr = new EnvironmentConfigManager();
                    List<EnvironmentUsersUser> UserList = _config.Environment.Users.User.Where(user => user.toDisplay == true/*.ToString()*/).ToList();
                    foreach (var user in UserList)
                    {
                        _config.Environment.Users.User.Remove(user);
                    }
                    for (int i = 0; i < UsernameTextBoxes.Count; i++)
                    {
                        var userName = UsernameTextBoxes[i];
                        var password = PasswordTextboxes[i];
                        RemoveButtons[i].Tag = true;
                        var encryptPassword = PasswordEncrption.RSAEncryption(password.Text);
                        _config.Environment.Users.User.Add(new EnvironmentUsersUser() {  userName = userName.Text, password = encryptPassword, toDisplay = true });
                    }
                    configmgr.Serilize<Config>(_configurationTabData._objectSources.getEnviromentFileName, _config);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all textboxes", "Warning", MessageBoxButtons.OK);
            }
        }
