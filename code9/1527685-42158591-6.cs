    static void Main(string[] args)
    {
        DateTime startClassZ = new DateTime(2017, 02, 09, 09, 00, 00);
        DateTime endClassZ = new DateTime(2017, 02, 09, 12, 00, 00);
        DateTime StartCurrent = new DateTime(2017, 02, 09, 10, 00, 00);
        DateTime EndCurrent = new DateTime(2017, 02, 09, 11, 00, 00);
        if(HasOverlap(startClassZ, endClassZ, StartCurrent, EndCurrent))
        {
            Console.WriteLine("clash");
        }
        else
        {
            Console.WriteLine("yay");
        }
        Console.Read();
    }
