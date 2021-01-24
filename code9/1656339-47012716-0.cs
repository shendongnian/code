    static void Main(string[] args)
    {
        var fileLines = new List<string>
        {
            "Lorem, Ipsum, is, simply, dummy, text, of, the, printing, and, typesetting,",
            "industry., Lorem, Ipsum, has, been, the, industry's, standard, dummy, text,",
            "ever, since, the, 1500s, when, an, ",
            "unknown, printer, took, a, galley, of, type, and, scrambled, it, to, make,",
            "a, type, specimen, book.,",
            "It, has, survived, not, only, five, centuries, but, also, the, leap,",
            "into, electronic, typesetting, remaining, essentially, unchanged.,",
            "It, was, popularised, in, the, 1960s, with, the, release,",
            "of, Letraset, sheets, containing, Lorem, Ipsum, passages, and, more, ",
            "recently, with, desktop, publishing,",
            "software, like, Aldus, PageMaker, including, versions, of, Lorem, Ipsum."
        };
        var filePath = @"f:\public\temp\temp.csv";
        var fileLinesColumns = File.ReadAllLines(filePath).Select(line => line.Split(','));
        var colWidths = new List<int>();
        // Remove this line to use file data
        fileLinesColumns = fileLines.Select(line => line.Split(','));   
        // Get the max length of each column and add it to our list
        foreach (var fileLineColumns in fileLinesColumns)
        {
            for (int i = 0; i < fileLineColumns.Length; i++)
            {
                if (i > colWidths.Count - 1)
                {
                    colWidths.Add(fileLineColumns[i].Length);
                }
                else if (fileLineColumns[i].Length > colWidths[i])
                {
                    colWidths[i] = fileLineColumns[i].Length;
                }
            }
        }
        // Write out our columns, padding each one to match the longest line
        foreach (var fileLineColumns in fileLinesColumns)
        {
            for (int i = 0; i < fileLineColumns.Length; i++)
            {
                Console.Write(fileLineColumns[i].PadRight(colWidths[i]));
            }
            Console.WriteLine();
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
