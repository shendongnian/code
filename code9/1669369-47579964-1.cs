	protected void btnSignUp_Click(object sender, EventArgs e)
	{
		string cusname = txtCustName.Text;
		string email = txtEmail.Text;
		string pass = txtPassword.Text;
		string confirm = txtConfirmPassword.Text;
		if (string.IsNullOrEmpty(cusname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirm))
		{
			txtCustName.Visible = true;
			txtEmail.Visible = true;
			txtPassword.Visible = true;
			txtConfirmPassword.Visible = true;
			//etc....
		
			ShowMessage("Fill all cradentials of customer.");
		}
		else
		{
			//.. Register user
			Response.Redirect("~/CustomerPanel/Dashboard.aspx");
		}
	}
