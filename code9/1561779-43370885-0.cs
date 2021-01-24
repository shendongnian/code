      static void Main(string[] args)
        {
            string s = "Test";
            var n = ASCIIEncoding.ASCII.GetBytes(s);
            for (int i = 0; i < s.Length; i++)
            {                
                Console.WriteLine($"Char {s[i]} - byte {n[i]}");
            }
        }
