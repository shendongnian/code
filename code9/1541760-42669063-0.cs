            string temp = "Data Source=" + tbServerName.Text + ";";
            temp += "Initial Catalog=" + tbDatabaseName.Text + ";";
            temp += "Persist Security Info=True;";
            temp += "User ID=" + tbUserId.Text + ";";
            temp += "Password=" + tbPassword.Text;
            var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            section.ConnectionStrings["iFishConnectionString"].ConnectionString = temp;
            configuration.Save();
