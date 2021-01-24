            Replace
            Employee employee = new Employee(); with
            List<Employee> employee = new List<Employee>();
        and
          SqlCommand cmd = new SqlCommand("Sp_GetById", con);
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@EmpId", Key);
    
          SqlDataReader rdr = cmd.ExecuteReader();
    
          if (rdr.HasRows == true)
          {
            while (rdr.Read())
            {
            employee.Add({
            Emp_Id = Convert.ToInt32(rdr["Emp_Id"]),
            EmpName = rdr[("EmpName")].ToString()
               });
            }
         }
