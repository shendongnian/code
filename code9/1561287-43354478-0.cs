    HashSet<int> linesHash = new HashSet<int>();
    var lines = file.ReadLines();
    for (int i = 0; i < numLinesToGet; i++)
    {
        int line=0;
        do
        { 
           line = rand.Next(0, lines.Length);
        }while(linesHash.Contains(line));
        linesHash.Add(line);
        linesAdded.Add(lines[line]);
    }
