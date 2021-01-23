    using System.Linq;
    string[] categories = { "electronic,sports", "abc,pqr", "xyz"};
    categories = categories.SelectMany(o => o.Split(',')).ToArray();
    
    foreach(var c in categories)
    {
    	Console.WriteLine(c);
    }
