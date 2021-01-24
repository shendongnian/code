        public static bool ValidateInput(string input)
        {
            //set maxColumn and maxRow sizes
            const string maxColumn = "BG";
            const int maxRow = 155;
            //parse input into inputColumn and inputRow
            string inputColumn = new string(input.TakeWhile(char.IsLetter).Select(char.ToUpper).ToArray());
            int inputRow = int.Parse(new string(input.Skip(inputColumn.Length).ToArray()));
            //make sure the length is at least as long as maxColumn (for comparing single letter column to double-letter column, for example)
            inputColumn.PadLeft(maxColumn.Length, ' ');
            //return comparison result (inclusive to maxColum and maxRow)
            return string.Compare(inputColumn, maxColumn) <= 0 && inputRow <= maxRow;
        }
