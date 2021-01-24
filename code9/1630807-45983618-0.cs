    using System;
    using System.Diagnostics;
    
    public class Program
    {
        [DebuggerStepThrough()]
        public static void Main()
        {
            try
            {
                throw new ApplicationException("test");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
