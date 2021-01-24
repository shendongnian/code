        private static List<string> _test = new List<string>();
        public List<string> Test { get => _test; set => _test = value; }
        
        static void Main(string[] args)
        {
            string numString = "abcd";
            _test.Add("ABcd");
            _test.Add("bsgd");
            string result = _test.Where(a => a.ToUpper().Equals(numString.ToUpper()) == true).FirstOrDefault();
            Console.WriteLine(result + " linq");
        }
