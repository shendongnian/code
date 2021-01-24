    [Flags]
    public enum E
    {
        Foo = 1 << 2,
        Bar = 1 << 4,
        Baz = 1 << 9,
        Planxty = Foo | Bar | Baz
    }
...
    var s = "16,4,512";
    E enumresult = 
        //  Split string by commas...
        s.Split(',')
        //  Parse each numeric substring in turn and cast the result to the enum type...
        .Select(nstr => (E)Int32.Parse(nstr))
        //  bitwise or each succeeding value against the rest
        .Aggregate((a, b) => a | b);
