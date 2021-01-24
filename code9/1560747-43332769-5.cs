        public static string GetSubExpression(this Regex pRegex, string pCaptureName)
        {
            string sRegex = pRegex.ToString();
            string sGroupText = @"(?<" + pCaptureName + ">";
            int iStartSearchAt = sRegex.IndexOf(sGroupText) + sGroupText.Length;
            string sRemainder = sRegex.Substring(iStartSearchAt);
            string sThis;
            string sPrev = "";
            int iOpenParenCount = 0;
            int iEnd = 0;
            for (int i = 0; i < sRemainder.Length; i++)
            {
                sThis = sRemainder.Substring(i, 1);
                if (sThis == ")" && sPrev != @"\" && iOpenParenCount == 0)
                {
                    iEnd = i;
                    break;
                }
                else if (sThis == ")" && sPrev != @"\")
                {
                    iOpenParenCount--;
                }
                else if (sThis == "(" && sPrev != @"\")
                {
                    iOpenParenCount++;
                }
                sPrev = sThis;
            }
            return sRemainder.Substring(0, iEnd);
        }
