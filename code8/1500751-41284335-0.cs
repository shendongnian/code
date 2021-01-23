        public void Test()
        {
            var input = "1234:D \n ABnCD\rE456 F\r\nGHIJ789\\nKL MNO012P QRST:) :-( aa:? aa *D* :)\r\nGHIJ789\nwww.ring.com ssd";
            var withMultipleSplitters = SplitStrings(new List<string>() {"\n", " ", "\r\n"}, 70, input);
            var withOneSplitter = SplitStrings(" ", 70, input);
            Debug.WriteLine("--------------------------------------");
            Debug.WriteLine($"Content of: {nameof(withMultipleSplitters)}");
            foreach (string s in withMultipleSplitters)
            {
                Debug.WriteLine(s);
            }
            Debug.WriteLine("--------------------------------------");
            Debug.WriteLine($"Content of: {nameof(withOneSplitter)}");
            foreach (string s in withOneSplitter)
            {
                Debug.WriteLine(s);
            }
        }
        private List<string> SplitStrings(List<string> splitters, int maxLen, string input)
        {
            List<string> output = new List<string>();
            while (true)
            {
                if (input.Length < maxLen)
                {
                    output.Add(input);
                    break;
                }
                int last = -1;
                int splitterLen = 0;
                foreach (string splitter in splitters)
                {
                    int splitIndex = input.LastIndexOf(splitter, maxLen);
                    if (last < splitIndex)
                    {
                        last = splitIndex;
                        splitterLen = splitter.Length;
                    }
                }
                if (last == -1)
                {
                    last = maxLen;
                }
                string sub = input.Substring(0, last);
                input = input.Substring(last + splitterLen); 
                output.Add(sub);
            }
            return output;
        }
        private List<string> SplitStrings(string splitter, int maxLen, string input)
        {
            List<string> output = new List<string>();
            while (true)
            {
                if (input.Length < maxLen)
                {
                    output.Add(input);
                    break;
                }
                int last = input.LastIndexOf(splitter, maxLen);
                if (last == -1)
                {
                    last = maxLen;
                }
                string sub = input.Substring(0, last);
                input = input.Substring(last + splitter.Length);
                output.Add(sub);
            }
            return output;
        }
