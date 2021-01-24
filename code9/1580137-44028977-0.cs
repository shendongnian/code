    //Get the lines from the file
    List<string> lines = System.IO.File.ReadAllLines("MyFile.txt").ToList();
    //Removed the lines which are empty or when split using ' ' contain items other the numbers >= 50000
    double d = 0;
    lines.RemoveAll(x => string.IsNullOrWhiteSpace(x) || x.TrimEnd(',').Split(' ').Any(y => !double.TryParse(y, out d) || double.Parse(y) < 50000));
    //Write the new file
    System.IO.File.WriteAllLines("MyFile2.txt", lines.ToArray());
