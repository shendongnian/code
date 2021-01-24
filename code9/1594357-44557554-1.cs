    class Employee
    {
       public string Name { get; set; }
    }
    
    // serializing
    var employees = new List<Employee>()
    {
      new Employee() {Name = "john"},
      new Employee() {Name = "alex"},
      new Employee() {Name = "susan"},
      new Employee() {Name = "bryan"},
    };
    
    var dict = new Dictionary<string, object>
    {
      ["employees"] = employees,
      ["status"] = "error",
      ["errormessage"] = "Not found employees"
    };
    var json = JsonConvert.SerializeObject(dict);
    
    // deserializing 
    dynamic deserialized = JsonConvert.DeserializeObject(json);
    string status = deserialized.status;
    string errorMessage = deserialized.errormessage;
    
    JArray jArray = deserialized.employees;
    List<Employee> deserializedEmployee = jArray.ToObject<List<Employee>>();
