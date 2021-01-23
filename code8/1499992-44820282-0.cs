        public static String compare(String str1, String str2)
        {
            String[] strArr1 = str1.Split(',');
            String[] strArr2 = str2.Split(',');
            int itr = 0;
            while (strArr1.Length == strArr2.Length && strArr2.Contains(strArr1[itr]))
            {
                itr++;
                if (itr == strArr1.Length)
                {
                    return "The Strings contains same values.";
                }
            }
            return "The Strings does not contain same values.";
        }
