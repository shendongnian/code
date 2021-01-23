    var exceptionList = new List<string> {
      "QPZ",
      "QPR"
    };
    
    foreach (var val in users)
     {
        if (val.Any(x => exceptionList.Contains(x.UserException))
        {
            listUsers.Add(
               val?.First(s => exceptionList.Contains(x.UserException))
            );
        }
        else
        {
            listUsers.AddRange(val);
        }
     }
