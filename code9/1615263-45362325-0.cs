    using (var output = new StreamWriter("Output.txt"))
    {
        foreach (var thisLine in File.ReadLines("Input.txt"))
        {
            var splits = thisLine.Split(';');
            output.WriteLine($"name = {splits[0]}");
            output.WriteLine($"lastname = {splits[1]}");
            output.WriteLine($"path = {splits[2]}");
        }
    }
