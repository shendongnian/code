    foreach (var val in users)
    {
        var match = val.FirstOrDefault(x => 
            x.UserException.Contains("QPZ") || x.UserException.Contains("QPR"));
        if (match != null)
        {
            listUsers.Add(match);
        }
        else
        {
            listUsers.AddRange(val);
        }
     }
