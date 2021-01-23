    string foundLine;
    if (sortedLines.TryGetValue(itemToFind, out foundLine))
    {
        ... // handle the found line
    }
    else
    {
        // add a new line:
        string newLine = // ...
        sortedLines.Add(itemToFind, newLine);
    }
