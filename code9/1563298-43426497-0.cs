    private void btnStart_Click(object sender, EventArgs e) {
      string userName = nameBox.Text;
      if (ValidUserName(userName)) {
        SecondForm nextForm = new SecondForm(userName);
        nextForm.Show();
        this.Hide();
      } else {
        // user name not valid
      }
    }
    private bool ValidUserName(String userName) {
      // logic to check if user name is valid
      return true;
    }
