        private static List<string> _test = new List<string>();
        public List<string> Test { get => _test; set => _test = value; }
        
        static void Main(string[] args)
        {
            string numString = "abcd";
            _test.Add("ABcd");
            _test.Add("bsgd");
            string str = String.Join(",", _test.ToArray()).Trim();
            Console.WriteLine(str);
            string result = _test.Where(a => a.ToUpper().Equals(numString.ToUpper()) == true).FirstOrDefault();
            Console.WriteLine(result + " linq");
        }
