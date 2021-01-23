    class Program
    {
        public int Divide_InExternalLib(int a, int b)
        {
            Console.WriteLine(string.Format("a={0}, b={1}", a, b));
            int result = a / b;
            Console.WriteLine(string.Format("Result = {0}", result));
            return result;
        }
        public void CallExternalFunction(Action funct)
        {
            try
            {
                funct.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception caught: {0}", ex.ToString()));
            }
        }
        
        static void Main(string[] args)
        {
            var p = new Program();
            int a = 6;
            int b = 2;
            p.CallExternalFunction(() => { p.Divide_InExternalLib(a, b); });
            b = 0;
            p.CallExternalFunction(() => { p.Divide_InExternalLib(a, b); });
            Console.ReadLine();
        }
    }
