    string[] lines = System.IO.File.ReadAllLines(@"c:\try.txt");
    
    int number;
    int sum = lines.Sum(line => Int32.TryParse(line, out number) ? number : 0);
    Console.WriteLine(sum);
