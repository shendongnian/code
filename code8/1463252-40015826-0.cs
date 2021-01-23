    if (UserExist > 0)
    {
        //EmpNo exists
        sqlCmd = new SqlCommand("update tbl_Login set Emp_Pass=@Pass where Emp_ID=@EmpID", sqlcon);
        sqlCmd.Parameters.AddWithValue("@EmpID", empNo);
        sqlCmd.Parameters.AddWithValue("@Pass", "1234");
        sqlCmd.ExecuteNonQuery(); // <- execute update
        lblExists.Text = "Password reset!";
    }// e
