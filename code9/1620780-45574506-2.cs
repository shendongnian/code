        public static void GetTheProduct(string input, Dictionary<string, Regex> regDictionary)
        {
            List<string> compareString = input.Split(new char[] { ',' }).ToList();
            foreach (string item in compareString)
            {
                string key = regDictionary.First(x => x.Value.IsMatch(item)).Key;
                Console.WriteLine("{0} : {1}", item, key);
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Regex> regDictionary = new Dictionary<string, Regex>();
            regDictionary.Add("Product A", new Regex("^C02.*"));
            regDictionary.Add("Product B", new Regex("^.*X02"));
            regDictionary.Add("Product C", new Regex("^.*A1700.*"));
            GetTheProduct("C02HGV32,N93XA1700D,J3429X02", regDictionary);
            Console.ReadLine();
        }
