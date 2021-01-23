    [Flags]
    public enum MyFlags
    {
        Flag0 = 1 << 0, // using the bitwise shift operator to make it more readable
        Flag1 = 1 << 1,
        Flag2 = 1 << 2,
        Flag3 = 1 << 3,
    }
    void a()
    {
        var flags = MyFlags.Flag0 | MyFlags.Flag1 | MyFlags.Flag3;
        Console.WriteLine(Convert.ToString((int) flags, 2)); // prints the binary representation of flags, that is "1011" (in base 10 it's 11)
        Console.WriteLine(flags); // as the enum has the Flags attribute, it prints "Flag0, Flag1, Flag3" instead of treating it as an invalid value and printing "11"
        Console.WriteLine(flags.HasFlag(MyFlags.Flag1)); // the Flags attribute also provides the HasFlag function, which is syntactic sugar for doing "(flags & MyFlags.Flag1) != 0"
    }
