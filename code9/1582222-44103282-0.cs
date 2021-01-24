    string abc = "abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine("Type in something you want to encrypt, using only lowercase letters.");
            var s = Console.ReadLine();
            if(s == null) return;
            for (var i = 0; i < s.Length; i++)
            {
                var a = s.Substring(i, 1);
                var x = abc.IndexOf(a, 0, abc.Length - 1, StringComparison.Ordinal);
                x = x + 3;
                if (x >= s.Length)
                {
                    x = x - s.Length;
                }
                var b = s.Substring(x, 1);
                s = s.Replace(a, b);
            }
            Console.WriteLine(s);
            Console.ReadKey();
