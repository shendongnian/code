    using System.Text.RegularExpressions;
    ...
    
    string[] lines = new string[] {
      "[DbServer]=localhost", 
      "[DbUser]=user", 
      "[DbPassword]=pass", 
      "[DbName]=testDb"};
    foreach (string line in lines) {
        string user = "<none>";
        var m = Regex.Match(line, @"^\s*\[DbUser\]\s*=\s*(\S+)\s*");
        if (m.Success) {
            user = m.Groups[1].Value;
            line = Regex.Replace(line, user, "Joe");
            #replaced User with Joe and reassigned it to line
        }
    }
		
