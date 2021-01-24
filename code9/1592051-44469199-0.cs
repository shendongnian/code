    string[] lines = System.IO.File.ReadAllLines(@"c:\try.txt");
    
    int number;
    int sum = lines.Select(line => Int32.TryParse(line, out number) ? number : 0).Sum();
    Console.WriteLine(sum);
