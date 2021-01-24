    static unsafe void Main()
    {
        var val = new sockaddr_nl
        {
            nl_family = 1, nl_pad = 2, nl_pid = 3, nl_groups = 4
        };
        byte[] data = new byte[14];
        Console.WriteLine("size of struct: " + sizeof(sockaddr_nl));
        // show value before
        Console.WriteLine(BitConverter.ToString(data));
        // thunk over the data
        fixed (byte* p = data)
        {
            *((sockaddr_nl*)p) = val;
        }
        // show value after
        Console.WriteLine(BitConverter.ToString(data));
    }
