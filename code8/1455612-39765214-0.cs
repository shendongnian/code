    namespace TestProject
    {
        using Newtonsoft.Json;
        using System;
    
        class Program
        {
            static void Main(string[] args)
            {
                var json = "{\"employeedetails\":{\"Fname\":\"awad\",\"Lname\":\"adadad\",\"Date_of_Birth\":\"09/13/2016\",\"Nic\":\"asdasdasd\",\"Gender\":\"Male\",\"Email\":\"asQsa @c\",\"Mobile_no\":\"1234234234\",\"Designation\":\"asdasd\",\"Date_of_join\":\"09/27/2016\",\"Department_name\":\"1\"}}";
                var employee = JsonConvert.DeserializeObject(json, typeof(Employee));
    
                Console.ReadKey();
            }
        }
    
        public class Employee
        {
            public EmployeeDetails employeedetails { get; set; }
        }
    
        public class EmployeeDetails
        {
            public string Empid { get; set; }
    
            public string Fname { get; set; }
    
            public string Lname { get; set; }
    
            public string Date_of_Birth { get; set; }
    
            public string Gender { get; set; }
    
            public string Email { get; set; }
    
            public int Mobile_no { get; set; }
    
            public string Designation { get; set; }
    
            public string Date_of_join { get; set; }
    
            public string Nic { get; set; }
    
            public string Department_name { get; set; }
        }
    }
