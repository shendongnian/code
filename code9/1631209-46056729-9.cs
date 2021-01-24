    class Program
    {
        static void Main(string[] args)
        {
            MyJsonObject company = new MyJsonObject();
            company.ChildName = "Department";
            company.Columns.Add("Id");
            company.Columns.Add("Name");
            company.Columns.Add("Location");
            MyJsonObject department = new MyJsonObject();
            department.ChildName = "Employee";
            department.Columns.Add("Id");
            department.Columns.Add("Name");
            department.Columns.Add("CompanyId");
            MyJsonObject employee1 = new MyJsonObject();
            employee1.Columns.Add("Id");
            employee1.Columns.Add("Name");
            employee1.Columns.Add("DepartmentId");
            MyJsonObject employee2 = new MyJsonObject();
            employee2.Columns.Add("Id");
            employee2.Columns.Add("Name");
            employee2.Columns.Add("DepartmentId");
            company.Children.Add(department);
            department.Children.Add(employee1);
            department.Children.Add(employee2);
            var json = JsonParser.Parse(company);
        }
    }
