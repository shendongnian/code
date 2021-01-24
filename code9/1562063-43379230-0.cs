    //Read the lines
    string[] lines = System.IO.File.ReadAllLines(@"food.txt");
    //Create the list
    List<string[]> grid = new List<string[]>();
    //Populate the list
    foreach (var line in lines) grid.Add(line.Split(','));
    //You can still access it like your 2D array:
    Console.WriteLine(grid[1][1]); //prints "orange"
