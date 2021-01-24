    var data = new[] { new[] { "a", "b", "c" }, new[] { "d", "e", "f" } };
    var colors = new[] { ConsoleColor.Red, ConsoleColor.Green };
    // Build a stream of commands with with some of them dealing
    // with formatting and others dealing with data output
    var commandBuilder = new List<Action>();
    var colorIndex = 0;
    foreach (var row in data)
    {
        foreach (var cell in row)
        {
            // Define a local variable 
            var cellColor = colors[colorIndex];
            commandBuilder.Add(() => SetCellColor(cellColor));
            commandBuilder.Add(() => DrawCell(cell));
            // flip colors
            colorIndex = ++colorIndex % colors.Length;
        }
        commandBuilder.Add(NewRow);
    }
    // Now, as we've built our command stream, play it:
    commandBuilder.ForEach(cmd => cmd());
    void SetCellColor(ConsoleColor color) { Console.ForegroundColor = color; }
    void DrawCell(string cellText) { Console.Write(cellText); }
    void NewRow() { Console.WriteLine(); }
