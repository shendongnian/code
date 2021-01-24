    static void Main(string[] args)
            {
    
                var sb = new StringBuilder();
                sb.Append("foo");
                sb.Append("bar");
    
                var str1 = sb.ToString();
                var str2 = sb.ToString();
    
                Console.WriteLine(str1);
                Console.WriteLine(str2);
                str1 += " str1";
                str2 += " str2";
    
                Console.WriteLine(str1);
                Console.WriteLine(str2);
    
                Console.ReadLine();
            }
