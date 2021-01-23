    long k = 123456789101112L;
    string str = Convert.ToBase64String(BitConverter.GetBytes(k));
    Console.WriteLine(str);
    long x = BitConverter.ToInt64(Convert.FromBase64String(str), 0);
    Console.WriteLine("{0} {1} {2}", k, x, x==k);
