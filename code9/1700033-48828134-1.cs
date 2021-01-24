    // inputs
    var input = "1,2,3,8,11,12";
    
    // parse them as ints (ensure they are in ascending order)
    var inputParsed = input.Split(',').Select(o => Convert.ToInt32(o)).OrderBy(o=> o).ToList();
    
    // will contain results
    var results = new List<List<int>>();
    
    // will contain the current group building
    var currentGroup = new List<int>();
    
    // while we have number to parse we add them
    while (inputParsed.Any())
    {
        // get the current number
        var currentNumber = inputParsed[0];
    
        // if the current group is empty OR if the last number in is 1 less we can group it
        if (!currentGroup.Any() || currentGroup.Last() == currentNumber - 1)
        {
            // add current number to the group
            currentGroup.Add(currentNumber);                  
        }
        else
        {
            // current number doesn't match with the group so close the
            // group as it's finished and create a new one for this number
                        
            // add the group to the list 
            results.Add(currentGroup);
    
            // create a new group
            currentGroup = new List<int>();
    
            // add current number to the group
            currentGroup.Add(currentNumber);
        }
    
        // remove the input we just checked
        inputParsed.RemoveAt(0);
    
        // check if there is any input left, if not the current group has to be added tp the results
        if (!inputParsed.Any())
        {
            // add the group to the list 
            results.Add(currentGroup);
        }
    }
    
    // parse single number as "1" and multiple number as "1-3"
    var parseGroups = new Func<List<int>, string>((group) =>
    {
        if (group.Count() == 1)
        {
            return group[0].ToString();
        }
        else
        {
            return group[0].ToString() + "-" + group.Last().ToString();
        }
    });
    
    // parse results
    var parsedResults = string.Join(",", results.Select(parseGroups));
