        static void Main(string[] args)
        {
            string[] musicinst = new string[4] { "cello", "guitar", "violin", "double bass" };
            char[] vowels = new char[5] { 'a', 'e', 'i' ,'o', 'u' };
            List<string> output = new List<string>();
            foreach (string s in musicinst)
            {
                string s1 = s;
                foreach (var v in vowels)
                {
                    if (s1.Contains(v))
                    {
                      s1=s1.Remove(s1.IndexOf(v),1);
                    }
                }
                output.Add(s1);
            }
            Console.ReadLine();
        }
