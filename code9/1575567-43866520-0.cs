        static void Main(string[] args)
        {
            string input = "your html string";
            string strReg = @"<img style=.+?src=""(.+?)""";
            Regex reg = new Regex(strReg,
                RegexOptions.Compiled | RegexOptions.Singleline);
            string youneed = reg.Match(input).Groups[1].Value;
            Console.WriteLine(youneed);
            Console.ReadLine();
        }
