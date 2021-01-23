    using System;
    using System.Text.RegularExpressions;
    
    namespace BLABLA
    {
        public static class ExcelCellAddressConvertor
        {
            public static string FromIntegerIndexToColumnLetter(int intCol)
            {
                var intFirstLetter = ((intCol) / 676) + 64;
                var intSecondLetter = ((intCol % 676) / 26) + 64;
                var intThirdLetter = (intCol % 26) + 65;
    
                var firstLetter = (intFirstLetter > 64)
                    ? (char)intFirstLetter : ' ';
                var secondLetter = (intSecondLetter > 64)
                    ? (char)intSecondLetter : ' ';
                var thirdLetter = (char)intThirdLetter;
    
                return string.Concat(firstLetter, secondLetter,
                    thirdLetter).Trim();
            }
    
            public static int ConvertColumnNameToNumber(string columnName)
            {
                var alpha = new Regex("^[A-Z]+$");
                if (!alpha.IsMatch(columnName)) throw new ArgumentException();
    
                char[] colLetters = columnName.ToCharArray();
                Array.Reverse(colLetters);
    
                var convertedValue = 0;
                for (int i = 0; i < colLetters.Length; i++)
                {
                    char letter = colLetters[i];
                    // ASCII 'A' = 65
                    int current = i == 0 ? letter - 65 : letter - 64;
                    convertedValue += current * (int)Math.Pow(26, i);
                }
    
                return convertedValue;
            }
        }
    }
