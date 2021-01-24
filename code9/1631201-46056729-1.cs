    class Program
    {
        static void Main(string[] args)
        {
            MyJsonObject company = new MyJsonObject();
            company.FirstLevelData.Add("Id", "1");
            company.FirstLevelData.Add("Name", "TestCompany");
            company.FirstLevelData.Add("Location", "TestLocation");
            MyJsonObject department = new MyJsonObject();
            department.FirstLevelData.Add("Id", "1.1");
            department.FirstLevelData.Add("Name", "TestDepartment");
            department.FirstLevelData.Add("CompanyId", "1");
            MyJsonObject employee = new MyJsonObject();
            employee.FirstLevelData.Add("Id", "1.1.1");
            employee.FirstLevelData.Add("Name", "TestEmployee");
            employee.FirstLevelData.Add("DepartmentId", "1.1");
            company.SecondLevelData.Add(department);
            department.SecondLevelData.Add(employee);
            var json = new JavaScriptSerializer(new SimpleTypeResolver()).Serialize(company);
        }
    }
