    // This will print to console every subpath
    for( int i = 1; i <= pathParts.Length; i++)
    {
        Console.WriteLine(string.Join("\\", pathParts.Take(i)));
    }
    
