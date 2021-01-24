    internal Tuple<int, string> GetBoth(string info)
    {
        string inputValue;
        int infor;
        Console.WriteLine("Information of the employee: {0}", info);
        inputValue = Console.ReadLine();
        infor = int.Parse(inputValue);
        return new Tuple<int, string>( infor, inputValue );
    }
    internal void MethodImCallingItFrom()
    {
        var result = GetBoth( "something" );
        int theInt = result.Item1;
        string theString = result.Item2;
    }
