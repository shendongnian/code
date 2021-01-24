    [CompilerGenerated]
    private sealed class <>c__DisplayClass0_0
    {
        public string userInput;
        public Func<string, bool> <>9__1;
        internal bool <Main>b__0(string[] entry)
        {
            IEnumerable<string> arg_20_0 = entry;
            Func<string, bool> arg_20_1;
            if ((arg_20_1 = this.<>9__1) == null)
            {
                arg_20_1 = (this.<>9__1 = new Func<string, bool>(this.<Main>b__1));
            }
            return arg_20_0.Any(arg_20_1);
        }
        internal bool <Main>b__1(string item)
        {
            return item.IndexOf(this.userInput, StringComparison.OrdinalIgnoreCase) > -1;
        }
    }
    public static void Main()
    {
        Program.<>c__DisplayClass0_0 <>c__DisplayClass0_ = new Program.<>c__DisplayClass0_0();
        Console.WriteLine("Using lambda");
        <>c__DisplayClass0_.userInput = "1";
        List<string[]> list = new List<string[]>();
        List<string[]> arg_3A_0 = list;
        string[] expr_2A = new string[2];
        expr_2A[0] = "1";
        string[] expr_32 = expr_2A;
        expr_32[1] = "2";
        arg_3A_0.Add(expr_32);
        List<string[]> source = list;
        IEnumerable<string[]> enumerable = source.Where(new Func<string[], bool>(<>c__DisplayClass0_.<Main>b__0));
        IEnumerator<string[]> enumerator = enumerable.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                string[] current = enumerator.Current;
                Console.WriteLine(string.Join(", ", current));
            }
        }
        finally
        {
            if (enumerator != null)
            {
                enumerator.Dispose();
            }
        }
    }
