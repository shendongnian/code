    var exceptionList = new List<string> {"QPZ","QPR"};
  
    foreach (var val in users)
    {
     var match = val.FirstOrDefault(x => exceptionList.Contains(x.UserException));
       if (match != null)
       {
          usersList.Add(match);
       }
       else
       {
          usersList.AddRange(val);
       }
    }
