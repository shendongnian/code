    string str = @"( (startswith(Name,'Bill'))  and  
    (substringof('sunset',Address))  and  
    (substringof('7421',Phone)) )";
    System.Text.RegularExpressions.Regex regex = new  System.Text.RegularExpressions.Regex(@"startswith\(([^\)]+)\)");
    System.Text.RegularExpressions.Match match = regex.Match(str);
    if (match.Success)
    {
      string tmp = match.Value;
      string destination = "@field LIKE '@val%'";
      tmp = tmp.Replace( "startswith(","");
      tmp = tmp.Replace( ")","");
      string[] keyvalue = tmp.Split(',');
      string field = keyvalue[0];
      string val = keyvalue[1];
      destination = destination.Replace("@field", field);
      destination = destination.Replace("@val", val.Replace("'",""));
      Console.WriteLine( destination );
    }
