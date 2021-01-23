    static void Main(string[] args)
    {
        int stackSize = 100;
        int num = 862;
        var stacks = new List<int>();
        while (num > stackSize)
        {
            stacks.Add(stackSize);
            num -= stackSize;
        }
        if (num > 0)
        {
            stacks.Add(num);
        }
    }
