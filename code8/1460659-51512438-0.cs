    string json = "[{\"ID\":\"27\",\"UserID\":\"1\",\"Name\":\"test1\",\"Description\":\"test1description\",\"StartTime\":\"\"},{\"ID\":\"29\",\"UserID\":\"1\",\"Name\":\"w\",\"Description\":\"ww\",\"StartTime\":\"12\"},{\"ID\":\"30\",\"UserID\":\"1\",\"Name\":\"qq\",\"Description\":\"qqqdescription\",\"StartTime\":\"1222\"},{\"ID\":\"31\",\"UserID\":\"1\",\"Name\":\"v\",\"Description\":\"vv\",\"StartTime\":\"1\"},{\"ID\":\"32\",\"UserID\":\"1\",\"Name\":\"n\",\"Description\":\"nnn\",\"StartTime\":\"111\"}]";
    
    var obj = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(json);
    
    List<Employee> employees = (obj).Select(x => new Employee
    {
        ID = (string)x["ID"],
        UserID = (string)x["UserID"]
    }).ToList();
                
    foreach (var emp in employees)
    {
        lvNewData.Items.Add(emp.ID);
        // add other things
    }   
