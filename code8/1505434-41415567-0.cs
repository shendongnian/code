    using System;
    using System.Text;
    
    class Test
    {
        static void Main(string[] args)
        {
            Action<StringBuilder> action1 = sb =>
            {
                Console.WriteLine(sb);
                sb = new StringBuilder("x");
            };
            Action<StringBuilder> action2 = sb =>
            {
                Console.WriteLine(sb);
                sb.Append("y");
            };
            Action<StringBuilder> action3 = sb =>
            {
                Console.WriteLine(sb);
                sb.Append("z");
            };
            
            Action<StringBuilder> all = action1 + action2 + action3;
            StringBuilder builder = new StringBuilder("a");
            all(builder);
            Console.WriteLine(builder);
        }
    }
