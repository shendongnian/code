    public short mul()
    {
        try {
            return checked((short)(a * b)); }
        catch(OverflowException exc) {
            Console.WriteLine(exc);
            return 0; // or whatever
        }
        return 0; // this goes as well
    }
