        public int Max(int number)
        {
            var numberAsCharArray = number.ToString().OrderByDescending(c => c).ToArray();
            var largestNumberAsString = new string(numberAsCharArray);
            return Int32.Parse(str);       
        }
