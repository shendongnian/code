    SqlConnection connection = new SqlConnection("server=DESKTOP-3DH5S38\\HR_SERVER;database=BMS_PRO_DB;Integrated Security =true");
    SqlCommand sqlCommand = new SqlCommand("Select * From tbl_LoginInfo where username=@user and password=@password", connection);
    connection.Open();
    sqlCommand.Parameters.AddWithValue("@user", UserName_Textbox.Text);
    sqlCommand.Parameters.AddWithValue("@password", Password_Textbox.Text);
    SqlDataReader dataReader = sqlCommand.ExecuteReader();
    if (dataReader.HasRows == true)
    {
        this.Hide();
        MainForm mainForm = new MainForm();
        mainForm.ShowDialog();
        this.Close();
    }
    else
    {
        MessageBox.Show("Check Username/Password !");
    }
