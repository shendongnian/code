        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Designation { get; set; }
        }
        using (IDbConnection db = new SqlConnection("SOME CONNECTION STRING")
        { 
            var employees = db.Query<Employee>("SELECT * FROM EMPLOYEE").ToList(); 
        }
