    static void Main(string[] args)
    {
        string [ ] arr = {"a", "c", "a", "o", "a", "o", "a", "l"};
        StringBuilder sb = new StringBuilder();
        int index = 0;
        foreach (string element in arr)
        {
            if(index % 2 != 0)
               sb.Append(element);
            index++;
        }
        Console.WriteLine(sb);
