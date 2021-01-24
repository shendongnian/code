    foreach (var currentList in personLists)
    {
        // process each list
        console.writeline(string.Format("People in code {0}:",currentList[0].Code));  //todo null check
        foreach (var person in currentList])
        {
            // process each person in the current list
            console.writeline(string.Format("  Person: {0}",person.Name));  //todo null check
            var personID = person.ID;
            var personCode = person.Code;
            var personName = person.Name;
            var personTime = person.Time;
        }
    }
