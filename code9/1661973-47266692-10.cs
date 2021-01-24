    var employees = new List<Employee>();
    using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand("select EMPLOYEE_ID, FIRST_NAME, SALARY from Employee", connection))
    {
        connection.Open();
        using(var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmployeeId = reader.GetInt32(reader.GetOrdinal("EMPLOYEE_ID"));
                employee.FirstName = reader.GetString(reader.GetOrdinal("FIRST_NAME"));
                employee.Salary = reader.GetInt32(reader.GetOrdinal("SALARY"));
                employees.Add(employee);
            }
        }
    }
    return employees;
