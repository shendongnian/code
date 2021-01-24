    // Read your lines
    var states = File.ReadAllLines(@"C:\states.txt");
    
    // Build a pipe delimited string (e.g. State1|State2|State3 ...) to use an a Regex
    var pattern = string.Join("|", states);
    
    // Now use that pattern to build a Regex to check against (using C# string interpolation)
    var regex = new Regex($@"\b{pattern}\b", RegexOptions.IgnoreCase);
 
    // Now loop through your data here and check each line
    string[] lines = File.ReadAllLines(@"C:\sampledata.dat");
    foreach (string s in lines)
    {
            var m = regex.Match(s);
            Console.WriteLine(m.Success); // false
            Console.WriteLine(s);
            Console.ReadLine();
    }
