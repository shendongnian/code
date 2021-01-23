    public class test_params
    {
        public void SomeMethod(String format, params Object[] prms) { Console.Write("#1: ");  Console.WriteLine(format, prms); }
        public void SomeMethod(String str, Exception ex, String format, params Object[] prms) { Console.Write("#2 "); Console.WriteLine("str={0} Excep={1}", str, ex.Message); Console.WriteLine(format, prms); }
        public void Test()
        {
            SomeMethod("", 1, 2, 3);                                            // #1:
            SomeMethod("{0} {1}", 1, 2);                                        // #1: 1 2
            SomeMethod("{0} {1}", 1, "p2", 3, 4);                               // #1: 1 p2
            SomeMethod("{0} {1}", new Exception("Test excep"), "p2");           // #2 str={0} {1} Excep=Test excep // p2
            SomeMethod("Str1", new Exception("Test excep"), "{0} {1}", 1, 2);   // #2 str=Str1 Excep=Test excep // 1 2
        }
    }
