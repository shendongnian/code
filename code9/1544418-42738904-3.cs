    // Load everything in memory
    string fileData = File.ReadAllText(@"D:\temp\myData.txt");
    // Split on the \r\n (I don't use Environment.NewLine because it 
    // respects the OS conventions and this could be wrong in this context
    string[] lines = fileData.Split(new string[] { "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
    // Now replace the remaining \n with a space 
    lines = lines.Select(x => x.Replace("\n", " ")).ToArray();
    foreach(string s in lines)
       Console.WriteLine(s);
