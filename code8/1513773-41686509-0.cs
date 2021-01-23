    class Program
    {
        static void Main(string[] args)
        {
            var strFunc = "10000/x";
            for (var i = 1; i < 10000; i++)
            {
                var strFuncRplacement = strFunc.Replace("x", i.ToString());
                var e = new Expression(strFuncRplacement);
                Console.WriteLine(e.Evaluate());
            }
            Console.ReadLine();
        }
    }
