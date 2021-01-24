    class Program
    {
        static int theYes = 0;
        delegate void operate1();
        delegate void operate2(string a);
        delegate void operate3(string a, uint x);
        static void Main(string[] args)
        {
            int i = 0;
            OperatorOnFilter myOperators = new OperatorOnFilter();
            myOperators.AddOrReplace(0, (operate1)delegate() { Console.Write("a"); theYes++; }); //1
            myOperators.AddOrReplace(1, (operate2)delegate(string a) { Console.Write(a); theYes++; }, "b"); //2
            myOperators.AddOrReplace(2, (operate3)delegate(string a, uint x) { for (uint j = 0U; j < x; j++) { Console.Write(a); theYes++; } }, "c", 3U); //4
            myOperators.ApplyOperations(new FilterManager(7));      //"abccc" 7 = 1 + 2 + 4
            myOperators.ApplyOperations(new FilterManager(3));     //"ab" 3 = 1 + 2
            myOperators.ApplyOperations(new FilterManager(6));    //"bccc" 6 = 2 + 4
            Console.WriteLine(theYes); // 11
            Console.ReadKey();
        }
    }
