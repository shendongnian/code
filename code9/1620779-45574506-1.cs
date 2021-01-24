        public static void GetTheProduct(string input, List<Regex> regList)
        {
            List<string> compareString = input.Split(new char[] { ',' }).ToList();
            foreach (string item in compareString)
            {
                if (regList[0].Match(item).Success)
                    Console.WriteLine("{0} : {1}", item, "Product A");
                else if (regList[1].Match(item).Success)
                    Console.WriteLine("{0} : {1}", item, "Product B");
                else if (regList[2].Match(item).Success)
                    Console.WriteLine("{0} : {1}", item, "Product C");
            }
        }
        static void Main(string[] args)
        {
            List<Regex> regexList = new List<Regex>() { new Regex("^C02.*"), new Regex("^.*X02"), new Regex("^.*A1700.*") };
            GetTheProduct("C02HGV32,N93XA1700D,J3429X02", regexList);
            Console.ReadLine();
        }
