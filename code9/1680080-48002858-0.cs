     Console.WriteLine("Enter The String : ");
     string input = Console.ReadLine();          
     string pattern = "(?<=\\<[^<>]*)\"(?=[^><]*\\>)";
     string output = Regex.Replace(input, pattern, "'");
     output = output.Replace(@"""", @"\""");
     Console.WriteLine(output);
     Console.ReadKey();
