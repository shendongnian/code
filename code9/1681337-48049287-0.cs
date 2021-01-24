      public List<Employee> Get(int id)
        {
            Employee emp = null;
            List<Employee> _employees = new List<Employee>();
            while (reader.Read())
            {
                emp = new Employee();
                emp.ClientId = Convert.ToInt32(reader.GetValue(0));
                emp.ClientName = reader.GetValue(1).ToString();
                _employees.Add(emp);
            }
            return _employees;
         }
