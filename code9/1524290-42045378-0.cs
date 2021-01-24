     public static void Test()
     {
           string str = "02 4D 00 68 6B 6A 68 6A 00 02 00 00 00 FF 02 5A 68 6B 6A 68 6A 00 02 00";
            string hash = "1:upx1:4D 00 68 6B ?? 68 6A:True";
            var parts = hash.Split(':');
            string title = parts[1];
            string hashhex = parts[2];
            string sPattern = hashhex.Replace("?", ".");
            Console.WriteLine($"Pattern={sPattern}");
            Console.WriteLine($"String={str}");
            if (Regex.IsMatch(str, sPattern))
            {
                Console.WriteLine("ok");
                Console.WriteLine($"MatchedTitle={title}");
            }
            else
            {
                Console.WriteLine("no");
            }
            Console.ReadLine();
     }
