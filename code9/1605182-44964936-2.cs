    using System;
    
    class SillyClass
    {
        public static string operator ==(SillyClass x, SillyClass y) => "equal";
        public static string operator !=(SillyClass x, SillyClass y) => "not equal";
    }
    
    class SillySubclass : SillyClass
    {
        public static string operator ==(SillySubclass x, SillySubclass y) => "sillier";
        public static string operator !=(SillySubclass x, SillySubclass y) => "very silly";
    }
    
    class Test
    {
        static void Main()
        {
            var x = new SillySubclass();
            var y = new SillySubclass();
            OpTest(x, y);
        }
        
        static void OpTest<T>(T x, T y) where T : SillyClass
        {
            Console.WriteLine(x == y);
            Console.WriteLine(x != y);
        }
    }
