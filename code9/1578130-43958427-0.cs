    for (uint i = 0; i <= 4294967295; i++)
    {
        byte[] bytes = BitConverter.GetBytes(i);
        Array.Reverse(bytes);
        string ipAddress = new IPAddress(bytes).ToString();
        Console.WriteLine(ipAddress);
    }
