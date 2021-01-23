     protected void submitBtn_Click(object sender, EventArgs e)
     {
        SqlConnection connect = new SqlConnection("Data  Source=THEBEAST;Initial Catalog=newregDB;Integrated Security=True;Pooling=False");
        {
            if (firstNameBox.Text == "" || surnameBox.Text == "" || dayDobList.Text == "" || monthDobList.Text == "" || yearDobList.Text == "" || genderList.Text == "" || postcodeBox.Text == "" || teleBox.Text == "" || emailBox.Text == "" || userBox.Text == "" || passwordBox.Text == "")
                Response.Write("<script>alert('Please ensure all fields have an entry');</script>");
            else
            {
                if (parentRadBtn.Checked)
                {
                    SqlCommand pa = new SqlCommand("INSERT INTO parent(parentID, firstname, surname, postcode, telephone, email, password) VALUES (@parentID, @firstname, @surname, @postcode, @telephone, @email, @password)", connect);
                    pa.Parameters.AddWithValue("@parentID", userBox.Text);
                    pa.Parameters.AddWithValue("@firstname", firstNameBox.Text);
                    pa.Parameters.AddWithValue("@surname", surnameBox.Text);
                    pa.Parameters.AddWithValue("@postcode", postcodeBox.Text);
                    pa.Parameters.AddWithValue("@telephone", teleBox.Text);
                    pa.Parameters.AddWithValue("@email", emailBox.Text);
                    pa.Parameters.AddWithValue("@password", passwordBox.Text);
                    connect.Open();
                    pa.ExecuteNonQuery();
                    connect.Close();
                    if (IsPostBack)
                    {
                        userBox.Text = "";
                        firstNameBox.Text = "";
                        surnameBox.Text = "";
                        postcodeBox.Text = "";
                        teleBox.Text = "";
                        emailBox.Text = "";
                        passwordBox.Text = "";
                    }
                }
                else if (childRadBtn.Checked)
                {
                    SqlCommand ca = new SqlCommand("INSERT INTO children(childID, firstname, dob, gender, password) VALUES (@childID, @firstname, @dob, @gender, @password)", connect);
                    ca.Parameters.AddWithValue("@childID", userBox.Text);
                    ca.Parameters.AddWithValue("@firstname", firstNameBox.Text);
                    ca.Parameters.AddWithValue("@dob", dayDobList.Text + monthDobList.Text + yearDobList.Text);
                    ca.Parameters.AddWithValue("@gender", genderList.Text);
                    ca.Parameters.AddWithValue("@password", passwordBox.Text);
                    connect.Open();
                    ca.ExecuteNonQuery();
                    connect.Close();
                    if (IsPostBack)
                    {
                        userBox.Text = "";
                        firstNameBox.Text = "";
                        dayDobList.Text = "";
                        monthDobList.Text = "";
                        yearDobList.Text = "";
                        genderList.Text = "";
                        passwordBox.Text = "";
                    }
                }
            }
        }
    }
