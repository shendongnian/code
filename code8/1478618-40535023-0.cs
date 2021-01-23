    static int[] DivideIntoStacks(int number, int stacksize)
    {
        int num = number;
        List<int> stacks = new List<int>();
        while (num > 0)
        {
            if (num - stacksize >= 0)
            {
                stacks.Add(stacksize);
                num -= stacksize;
            }
            else
            {
                stacks.Add(num);
                break;
            }
        }
        return stacks.ToArray();
    }
