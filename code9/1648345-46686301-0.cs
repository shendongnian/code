    class Program
    {
        static void Main(string[] args)
        {
            var newHandlerObject = new SomethingHandler.NestOfFunctions("SaltAndPepperOn");
            var result = newHandlerObject.HandleStuff("Salad");
            Console.WriteLine(result);
        }
    }
    public class SomethingHandler
    {
        public class NestOfFunctions
        {
            private string _someGlobalSalt;
            public NestOfFunctions(string salt)
            {
                _someGlobalSalt = salt;
            }
            public string HandleStuff(string input)
            {
                return input + "With" + _someGlobalSalt;
            }
        }
    }
