        public static string GetSubExpression(this Regex pRegex, string pCaptureName)
        {
            string sRegex = pRegex.ToString();
            string sGroupText = @"(?<" + pCaptureName + ">";
            int iStartSearchAt = sRegex.IndexOf(sGroupText) + sGroupText.Length;
            string sRemainder = sRegex.Substring(iStartSearchAt);
            string sSingle;
            int iOpenParenCount = 0;
            int iEnd = 0;
            for (int i = 0; i < sRemainder.Length; i++)
            {
                sSingle = sRemainder.Substring(i, 1);
                if (sSingle == ")" && iOpenParenCount == 0)
                {
                    iEnd = i;
                    break;
                }
                else if (sSingle == ")")
                {
                    iOpenParenCount--;
                }
                else if (sSingle == "(")
                {
                    iOpenParenCount++;
                }
            }
            return sRemainder.Substring(0, iEnd);
        }
