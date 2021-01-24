    static void Main(string[] args)
    {
        Hashtable hashtable = new Hashtable();
        int NOP = 0;
        Console.WriteLine("How many people to gift?");
        NOP = Convert.ToInt32(Console.ReadLine());
        for(int i=0;i<NOP;i++)
        {
            printout(ref hashtable, NOP);
            NOP--;
        }
        printout(ref hashtable, NOP);
        foreach (string key in hashtable.Keys)
        {
            Console.WriteLine(String.Format("{0}: {1}", key, hashtable[key]));
        }
        Console.Read();
    }
