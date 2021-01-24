    List<string> file1 = new List<string>();
    
    Console.WriteLine("Enter the path to the folder");
    string path1 = Console.ReadLine();
    
    file1.AddRange(System.IO.File.ReadAllLines(path1));
