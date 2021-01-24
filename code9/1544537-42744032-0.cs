    public Form1() {
      InitializeComponent();
      ClearLabels();
      SetLabels();
    }
    private void createButton_Click(object sender, EventArgs e) {
      string statusString = "";
      if (!ValidUserInput(out statusString)) {
        lblStatus.Text = statusString;
      }
      else {
        ///OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|FAMDatabase.accdb");
        //OleDbCommand fcmd = new OleDbCommand("INSERT INTO Login([UserName],[Password])" + "values(@username,@password)", con);
        //fcmd.Parameters.AddWithValue("@username", newUserTextBox.Text);
        //fcmd.Parameters.AddWithValue("@password", newPasswordTextBox.Text);
        //con.Open();
        //int i = fcmd.ExecuteNonQuery();
        //con.Close();
        MessageBox.Show("User Successfully Created","", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        //this.Close();
      }
    }
    private bool ValidUserInput(out string message) {
      ClearLabels();
      if (string.IsNullOrEmpty(newUserTextBox.Text)) {
        reqName.Text = ("Please enter a User Name");
        message = "UserName can not be blank!";
        return false;
      }
      if (string.IsNullOrEmpty(newPasswordTextBox.Text)) {
        reqPW.Text = ("Please enter a Password");
        message = "Password can not be blank!";
        return false;
      }
      if (string.IsNullOrEmpty(newPasswordTextBox2.Text)) {
        reqPW2.Text = ("Please enter a Password ");
        message = "Password verification can not be blank!";
        return false;
      }
      if (newPasswordTextBox.Text != newPasswordTextBox2.Text) {
        reqPW.Text = ("Passwords Do Not Match");
        reqPW2.Text = ("Passwords Do Not Match");
        message = "Password must match!";
        return false;
      }
      message = "Valid User Input";
      return true;
    }
    private void ClearLabels() {
      reqName.Text = "";
      reqPW.Text = "";
      reqPW2.Text = "";
      lblStatus.Text = "";
    }
    private void SetLabels() {
      ClearLabels();
      if (string.IsNullOrEmpty(newUserTextBox.Text)) {
        reqName.Text = "Please enter a User Name";
      }
      if (string.IsNullOrEmpty(newPasswordTextBox.Text)) {
        reqPW.Text = "Please enter a Password";
      }
      if (string.IsNullOrEmpty(newPasswordTextBox2.Text)) {
        reqPW2.Text = "Please enter a Password";
      }
      lblStatus.Text = "Enter userName and password";
    }
    private void newUserTextBox_TextChanged(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(newUserTextBox.Text)) {
        reqName.Text = "Please enter a User Name";
      }
      else {
        reqName.Text = "";
      }
    }
    private void newPasswordTextBox_TextChanged(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(newPasswordTextBox.Text)) {
        reqPW.Text = "Please enter a Password";
      } else {
        reqPW.Text = "";
      }
    }
    private void newPasswordTextBox2_TextChanged(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(newPasswordTextBox2.Text)) {
        reqPW2.Text = "Please enter a Password";
      } else {
        reqPW2.Text = "";
      }
    }
