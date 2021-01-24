    if (string.IsNullOrEmpty(chooseService.Text))
      MessageBox.Show("Please specify the department.");
    else
    {
      this.Hide();
      MainMenu login = new MainMenu(chooseService.Text);
      login.Show();
    }
