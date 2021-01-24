    var n = 1234;
    var c = "FOO";
    var d = 1234.56;
    var s = string.Format("{0}{1,8}", c, n); // The ",8" denotes up to 8 leading spaces.
    Console.WriteLine("{0}", s);
    s = string.Format("{0}{1,8}", c, n)
        .Replace(' ', '.');          // Change leading space to period.
    Console.WriteLine("{0}", s);
    s = string.Format("$_{0,8}", n)  // Up to 8 leading spaces.
        .Replace(' ', 'x')           // Replace spaces with 'x'.
        .Replace('_', ' ');          // Replace the leading underscore with space.
    Console.WriteLine("{0}", s);
    s = string.Format("$_{0,12:#,#.##}", d) // Decimal format with leading spaces.
        .Replace(' ', '~')           // Replace spaces with '~'
	    .Replace('_', ' ');          // Replace the leading underscore with space.
    Console.WriteLine("{0}", s);
