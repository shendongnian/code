     class Program
        {
            static void Main(string[] args)
            {
                var s1 = "hellohjhghello";
                var s2 = "lo";
                var occurence = 0;
                Occurrences(s1, s2, ref occurence);
                Console.WriteLine("{0} is repeated {1} times", s2, occurence);
                Console.ReadLine();
            }
    
            static void Occurrences(string s1, string s2, ref int occurence)
            {
                var index = s1.IndexOf(s2);
                if (index > -1)
                {
                    occurence++;
                    s1 = s1.Substring(index + s2.Length);
                    Occurrences(s1, s2, ref occurence);
                }
            }
        }
