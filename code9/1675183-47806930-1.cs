    public static void Main()
    {
        char singleLetter = 'B';
        short num = 35;
        Console.WriteLine("{0} {1}", num, singleLetter);
        singleLetter = Convert.ToChar(num);
        Console.WriteLine(singleLetter);
        Console.WriteLine("{0} {1}", sizeof(short), sizeof(char));
        Console.ReadLine();
    }
