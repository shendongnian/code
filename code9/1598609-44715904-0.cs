        public void foo()
        {
            string input = "A sample input a*b#c@d";
            string unwanted = "*'\",_&#^@";
            List<char> unwantedChars = unwanted.ToList<char>();
            StringBuilder sb = new StringBuilder();
            input = input.Replace(' ', '-');
            foreach(char c in input)
            {
                if (!unwantedChars.Any(x => x == c))
                    sb.Append(c);
            }
            string output = sb.ToString(); //A-sample-input-abcd
        }
