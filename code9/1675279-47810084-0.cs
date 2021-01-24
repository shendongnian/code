    public class EmployeeContainer
    {
            public Employee GetEmployeeJSONResult { get; set; }
    }
    
...
    Employee responseObject = serializer.Deserialize<EmployeeContainer>(json)?.GetEmployeeJSONResult;
