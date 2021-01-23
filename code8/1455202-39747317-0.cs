    class Program
    {
        public int Divide_InExternalLib(int a, int b)
        {
            int result = a / b;
            Console.WriteLine("Result = {0}", result);
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
            int a = 10;
            int b = 11;
            p.CallExternalFunction(() => { p.Divide_InExternalLib(a, b); });
            b = 0;
            p.CallExternalFunction(() => { p.Divide_InExternalLib(a, b); });
            Console.ReadLine();
        }
    }
