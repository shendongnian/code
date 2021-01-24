            var Connection = new SqlConnectionStringBuilder();
            Connection.DataSource = ServerNameTextBox.Text;
            Connection.InitialCatalog = DatabaseTextbox.Text;
            Connection.UserID = UserNameTextBox.Text;
            Connection.Password = PasswordTextBox.Text;
            var connString = Connection.ConnectionString; 
