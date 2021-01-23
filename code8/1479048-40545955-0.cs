     static void Main(string[] args)
        {
            string text = "tæst";
            string s = string.Empty;
            s = text.Replace("æ", "e");
            Console.WriteLine(s);
            Console.ReadKey();
        }
