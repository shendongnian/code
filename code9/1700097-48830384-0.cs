    string[] separator = new string[] { "." };  
    var result = perlVersions
       .OrderByDescending(s => int.Parse(s.Split(separator, StringSplitOptions.None)[1]))
       .OrderByDescending(s => int.Parse(s.Split(separator, StringSplitOptions.None)[0]))
       .ToList();
