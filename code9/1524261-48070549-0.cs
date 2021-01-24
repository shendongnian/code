    string SingleEntry(int number)
    {
        char[] array = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
        Stack<string> entry = new Stack<string>();
        List<string> list = new List<string>();
        int bas = 26;
        int remainder = number, index = 0;
        do
        {
            if ((remainder % bas) == 0)
            {
                index = bas;
                remainder--;
            }
            else
                index = remainder % bas;
            entry.Push(array[index].ToString());
            remainder = remainder / bas;
        }
        while (remainder != 0);
        string s = "";
        while (entry.Count > 0)
        {
            s += entry.Pop();
        }
        return s;
    }
