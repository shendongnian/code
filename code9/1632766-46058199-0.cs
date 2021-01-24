        public static bool ValidateInput(string input)
        {
            //set maxColumn and maxRow sizes
            const string maxColumn = "BG";
            const int maxRow = 155;
            //initialize input parse variables
            string inputColumn = "";
            int inputRow = int.MaxValue;
            //use only upper-case (to aid in comparison)
            input = input.ToUpper();
            //parse input into inputColumn and inputRow
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    inputRow = int.Parse(input.Substring(i));
                    break;
                }
                inputColumn += input[i];
            }
            //make sure the length is at least as long as maxColumn (for comparing single letter column to double-letter column, for example)
            inputColumn.PadLeft(maxColumn.Length, ' ');
            //return comparison result (inclusive to maxColum and maxRow)
            return string.Compare(inputColumn, maxColumn) <= 0 && inputRow <= maxRow;
        }
