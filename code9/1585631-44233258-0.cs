        static int romanToDecimal(string romanNums)
        {
            int result = 0;
            int[] deci = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] roman = { "M", "CM", "D", "CD", "C", "XD", "L", "XL", "X", "IX", "V", "IV", "I" };
            for (var i = 0; i < deci.Length; i++)
            {
                while (romanNums.IndexOf(roman[i]) == 0)
                {
                    result += deci[i];
                    romanNums = romanNums.Substring(roman[i].Length);
                }
            }
            return result;
        }
