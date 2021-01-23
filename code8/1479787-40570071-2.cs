    using System.Linq;
    ...
    string str = "string1";
    if (set1.Values.Any(x => x == str))
    {
         Console.WriteLine("Contains");
    }
    else
    {
         Console.WriteLine("Does Not Contains");
    }
