    using System;
    using System.Text;
    
    delegate void RefAction<T>(ref T arg);
    
    class Test
    {
        static void Main(string[] args)
        {
            RefAction<StringBuilder> action1 = (ref StringBuilder sb) =>
            {
                Console.WriteLine(sb);
                sb = new StringBuilder("x");
            };
            RefAction<StringBuilder> action2 = (ref StringBuilder sb) =>
            {
                Console.WriteLine(sb);
                sb.Append("y");
            };
            RefAction<StringBuilder> action3 = (ref StringBuilder sb) =>
            {
                Console.WriteLine(sb);
                sb.Append("z");
            };
            
            RefAction<StringBuilder> all = action1 + action2 + action3;
            StringBuilder builder = new StringBuilder("a");
            all(ref builder);
            Console.WriteLine(builder);
        }
    }
