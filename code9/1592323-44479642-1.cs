    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random(1);
            bool[] _arr = new bool[1500];
            for (int i = 0; i < 1500; i++)
            {
                var x = true;//r.Next() == 1 ? true : false;
                _arr[i] = x;
            }
            BigInteger rtrnVal = 0;
            for (int a = _arr.Count() - 1; a >= 0; a--)
            {
                rtrnVal = rtrnVal + (_arr[a] ? BigInteger.Pow(2, a) : 0);
            }
            Console.WriteLine(rtrnVal);
            Console.ReadLine();
        }
    }
