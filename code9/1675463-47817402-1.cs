     // Do we have OU?
     bool hasOU = data.ContainsKey("OU");
     // How many OU do we have?
     int ouCount = data.ContainsKey("OU") ? data["OU"].Length : 0;
     // Name(s) of the user?
     if (data.TryGetValue("CN", out var names)) {
       // names is the array of the user Names
     }
     else {
       // No CN, no names 
     }  
      
