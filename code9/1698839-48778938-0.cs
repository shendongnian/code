        string query = "SELECT 'Employee Name' FROM dbo.Employees WHERE EmployeeID = @HolidayEmployeeID";
        using (SqlConnection cn = new SqlConnection())
        using (SqlCommand cmd = new SqlCommand(query, cn))
        {
            cmd.Parameters.Add("@HolidayEmployeeID", SqlDbType.UniqueIdentifier).Value = holiday_EmployeeIDTextBox.Text;
            cn.Open();
            dim result = cmd.ExecuteScalar();
            cn.Close();
            HolEmpName.Text = result.ToString();        
        }
