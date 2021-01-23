        public static bool Condition(string x)
        {
            bool check1 = x.Contains("ML");
            bool check2 = x.Contains("KG");
            bool result = false;
            if(check1)
            {
                x = x.Replace("ML", "");
                var arr = x.Where(y => !char.IsDigit(y));
                result = arr.Count() == 0;
            }
            else if(check2)
            {
                x = x.Replace("KG", "");
                var arr = x.Where(y => !char.IsDigit(y));
                result = arr.Count() == 0;
            }
            return result;
        }
        public static void Main(string[] args)
        {
            string input = "124521teKGst45125 100KG10 fdfdfdf";
            string[] arrayResult = input.Split(' ').Where(x => Condition(x)).ToArray();
            string result = string.Join(", ", arrayResult);
        }
 
