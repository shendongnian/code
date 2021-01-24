    public class EmployeeContainer
    {
            public Employee GetEmployeeJSONResult { get; set; }
    }
    
...
    Employee responseObject = JsonConvert.DeserializeObject<EmployeeContainer>(json)?.GetEmployeeJSONResult;
