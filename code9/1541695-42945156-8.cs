        /// <summary>
        /// Encodes the 'input' parameter into a string of characters defined by the allowed list (0-9, A-Z) 
        /// </summary>
        /// <param name="input">Integer that is to be encoded as a string</param>
        /// <param name="maxLength">If zero, the string is returned as-is. If non-zero, the string is truncated to this length</param>
        /// <returns></returns>
        static String EncodeInt32AsString(Int32 input, Int32 maxLength = 0)
        {
            // List of characters allowed in the target string 
            Char[] allowedList = new Char[] {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z' };
            Int32 allowedSize = allowedList.Length;
            StringBuilder result = new StringBuilder(input.ToString().Length);
            Int32 moduloResult;
            while (input > 0)
            {
                moduloResult = input % allowedSize;
                input /= allowedSize;
                result.Insert(0, allowedList[moduloResult]);
            }
            if (maxLength > result.Length)
            {
                result.Insert(0, new String(allowedList[0], maxLength - result.Length));
            }
            if (maxLength > 0)
                return result.ToString().Substring(0, maxLength);
            else
                return result.ToString();
        }
