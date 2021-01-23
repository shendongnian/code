    var query = dice.Where(...); // not executed
    query = query.GroupBy(...);  // not executed
    query = query.Select(...);   // not executed
    query = query.OrderBy();     // not executed
    var result = query.ToArray();// executed only at this moment;
    // or in foreach loop
    foreach(var item in query){  // 
       //
    }
  
