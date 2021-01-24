            var stringlist = new List<string> { "RGBI1red", "green", "RGBI1pink", "purple" };
            stringlist = stringlist.Select(x => x.Replace("RGBI1", "")).ToList();
            stringlist.ForEach(x => Console.WriteLine(x));
    
    -->
       red
       green
       pink
       purple
