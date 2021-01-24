    string str = "String";
    var blah = new Concrete<StringBuilder>(new StringBuilder(str));
    Console.WriteLine(blah.Data); // "String"
    // to change the string to "Assign", call Clear() then Append()
    blah.Data.Clear();
    blah.Data.Append("Assign");
    Console.WriteLine(blah.Data);
