    public Employee FindEmpById(int key)
    {
        using (SqlConnection conn = db.CreateConnection())
        using (SqlCommand cmd = new SqlCommand("Sp_GetEmployeeById", conn)) {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", key);
            var employee = new Employee();
            conn.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader()) {
                if (rdr.Read()) {
                    employee.Emp_Id = Convert.ToInt32(rdr["Emp_Id"]);
                    employee.EmpName = rdr["EmpName"].ToString();
                    employee.Email = rdr["Email"].ToString();
                    employee.Psw = rdr["Psw"].ToString();
                }
            }
            return employee;
        }
    }
