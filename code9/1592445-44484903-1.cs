    Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
    ...
    List<string> Course_result = new List<string>();    
    ...
    //in loop
    Course_result.Add(UppercaseWords(m.ToString()));
    ...
    //after loop
    if (!result.ContainsKey("Course")) result.Add("Course",Course_result);
    else result["Course"]=Course_result; 
