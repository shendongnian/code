        protected void btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployee.Text))
            {
                MessageBox.Show("You must supply an Employee Number");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("You must supply a Password");
                return;
            }
            if (IsAuthenticated())
            {
                MessageBox.Show("Welcome " + txtEmployee.Text);
            }
            else
            {
                MessageBox.Show("The Username or Password you entered is incorrect. Please try again");
            };
        }
        private bool IsAuthenticated()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spValidateCredentials", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Employee", SqlDbType.Int).Value = txtEmployee.Text;
                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DateTime.Parse(txtPassword.Text);
                conn.Open();
                return ((int)cmd.ExecuteScalar() > 0);
            }
        }
