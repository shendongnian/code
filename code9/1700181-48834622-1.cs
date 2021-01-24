    namespace WebApplication1
    {
        class ExternalFunctions
        {
            [DllImport("MathLibrary.dll")]
            public static extern bool fibonacci_next();
        }
        class Program
        {
            static void Main()
            {
                //call it
                var foo = ExternalFunctions.fibonacci_next();
            }
        }
    }
