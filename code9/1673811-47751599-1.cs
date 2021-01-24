    var inner = new ObjectType {R = new Random(12345)};
    var outer = new Container  {AnObject = inner};
    var clone = Cloner.Clone(outer);
    Console.WriteLine(clone.AnObject.R.Next()); // Prints 143337951
    Console.WriteLine(outer.AnObject.R.Next()); // Also prints 143337951
