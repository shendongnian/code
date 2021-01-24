    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActie { get; set; }
    }
    using (var conn = new SqlConnection("Your Db Connection String"))
    {
        SqlCommand cmd = new SqlCommand("SELEC * FROM Employee WHERE IsActive = 1", conn);
        cmd.CommandType = CommandType.Text;
        conn.Open();
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                var emp = new Employee();
                emp.Id = reader.GetInt32(0);
                emp.Name = reader.GetString(1);
                emp.Salary = reader.GetDouble(2);
                emp.DateOfBirth = reader.GetDateTime(3);
                emp.IsActie = reader.GetBoolean(4);
                employees.Add(emp);
            }
        }
        SqlCommand updateCommand = new SqlCommand("UPDATE Employee SET Salary=@salary WHERE Id=@id", conn);
        updateCommand.Parameters.Add(new SqlParameter("@salary", SqlDbType.Float));
        updateCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        foreach (var employee in employees)
        {
            double salary = CalculateSalary();
            updateCommand.Parameters["@salary"].Value = salary;
            updateCommand.Parameters["@id"].Value = employee.Id;
            updateCommand.ExecuteNonQuery();
        }
    }
