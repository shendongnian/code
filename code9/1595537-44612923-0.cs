        string[] Old= new string[3]{"Thomas", "Eliza","John"};
        string[] New= new string[3]{"Thomas", "Eliza", "Beth"};
        var intersect = New.Intersect(Old, StringComparer.InvariantCultureIgnoreCase).ToArray();
        var loggedIn = New.Where(x=> !intersect.Contains(x)).Select(x=>x).ToList();
        var loggedOut = Old.Where(x=> !intersect.Contains(x)).Select(x=>x).ToList();
        foreach(var s in loggedIn)
          Console.WriteLine(s + " has logged in ");
        foreach(var s in loggedOut)
          Console.WriteLine(s + " has logged out ");
