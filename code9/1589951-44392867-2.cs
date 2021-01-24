    class B 
    {
        ...
 
        // Logic: multiply with possible Overflow exception
        // Let us be nice and document the exception 
        ///<exception cref="System.OverflowException">
        ///when a or (and) b are too large
        ///</exception> 
        public short mul()
        {
            // Do we know how to process the exception at the place? 
            // No. There're many reasonable responses: 
            // - stop execution
            // - use some special/default value (e.g. -1, short.MaxValue)   
            // - switch to class C which operates with int (or BigInteger) etc.
            // That's why we don't catch exception here  
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
                // Proper place to catch the exception: only here, at UI, 
                // we know what to do with the exception:
                // we should print out the exception on the Console
                Console.WriteLine(exc); 
            } 
        }
    }
