    s = "g";
    string[] color = { "greena", "browna", "bluea" };
    query = color;
    Console.WriteLine(query.Where(c => c.Contains(s)).Count());
    // Outputs 1 because g appears only in greena
    s = "g";
    // query still contains the original color list
    Console.WriteLine(query.Where(c => c.Contains(s)).Count());   
    // Outputs 3 because a appears in all three
