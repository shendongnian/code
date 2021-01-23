    #if DEBUG
    namespace Test
    #else
    namespace TestB
    #endif
    {
        public class Program
	    {
		    public static void Main()
		    {
			    Console.WriteLine(new Program().GetType().FullName);
                Console.ReadLine();
		    }
	    }
    }
