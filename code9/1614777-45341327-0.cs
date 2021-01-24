    private void Save()
    {
        Properties.Settings.Default.UserEmail = this.txtEmail.Text;
        Properties.Settings.Default.Save();
    }
