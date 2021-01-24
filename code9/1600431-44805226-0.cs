     var input = "ISA~this is date~ESA|ISA~this is more data~ESA|";
     var pattern = "ISA";
     var matches = Regex.Split(input, pattern).ToList();
     //This removes the first element which is always empty.
     matches.RemoveAll(a => a == String.Empty);
    //This adds the pattern back into the string which is needed in my case.
    var returnValue = matches.Select(x => "ISA" + x).ToList();
