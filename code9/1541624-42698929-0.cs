    PrincipalContext adContext = new PrincipalContext(ContextType.Machine);
    private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (adContext)
                {
                    if (adContext.ValidateCredentials(txtUsername.Text, txtPassword.Password))
                    {
                        MainWindow main = new MainWindow();
                        
                        main.Show();
                        main.txtLoggedInUser.Text = UserPrincipal.Current.DisplayName;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password!");
                    }
                }
            }
            catch(Exception ex)
            {
                var exceptionDialog = new MessageDialog
                {
                    Message = { Text = ex.ToString() }
                };
                await DialogHost.Show(exceptionDialog, "RootDialog");
            }
        }
