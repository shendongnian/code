    File.WriteAllText("text.txt","a\n\n\n");
    var lines=File.ReadAllLines("text.txt");
    //The last line isn't ignored
    Trace.Assert(lines.Length==3);
    //The last line *is* empty
    Trace.Assert(lines[2]=="");
    Trace.Assert(lines[lines.Length -1]=="");
    Trace.Assert(lines.Last()=="");
    //So is any empty line
    Trace.Assert(lines[2]=="");
