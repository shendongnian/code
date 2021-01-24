    class B 
    {
        ...
 
        // Logic: multiply with possible Overflow exception
        public short mul()
        {
            return checked((short)(a * b));
        }
    }
...
    class MainClass
    {
        // UI: perform operation and show the result on the console
        public static void Main(string[] args)
        {
            B m1 = new B(1000, 500);
          
            try 
            { 
                m1.mul();
            }
            catch (OverflowException exc) 
            { 
                // proper way to catch the exception: only here at UI 
                // we know what to do with the exception:
                // we should print out the exception on the Console
                Console.WriteLine(exc); 
            } 
        }
    }
