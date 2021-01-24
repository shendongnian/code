      Employee employee = new Employee();
      SqlCommand cmd = new SqlCommand("Sp_GetById", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@EmpId", Key);
      SqlDataReader rdr = cmd.ExecuteReader();
      if (rdr.HasRows == true)
      {
        while (rdr.Read())
        {
           employee.Emp_Id = Convert.ToInt32(rdr["Emp_Id"]);
           employee.EmpName = rdr[("EmpName")].ToString();
        }
     }
     else
     {
       return null;
     }
    return employee;
