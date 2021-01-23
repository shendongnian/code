    var s = string.Concat(Enumerable.Repeat("0123456789", 12));
    var a = new char[6][] { s.ToCharArray(0, 20), s.ToCharArray(20, 20), s.ToCharArray(40, 20), 
                         s.ToCharArray(60, 20), s.ToCharArray(80, 20), s.ToCharArray(100, 20) };
    // or a bit less efficient LINQ version
    char[][] arr = Enumerable.Range(0, 6).Select(i => s.ToCharArray(i * 20, 20)).ToArray();
