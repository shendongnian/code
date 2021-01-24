    for (int i = 0; i < onlyB.Count(); i++) // go through every element in the collection
    {
        string line = onlyB.ElementAt(i); // get the current element at index i
        if (line == "_") continue; // if the element is a '_', ignore it
        // write to the console, or however you want to output.
        Console.WriteLine(string.Format("line {0}: {1}", i, line));
    }
