    public int addFromString(string str)
    {
            int parsedNumber = 0;            
            int result = 0;
    
            if (string.IsNullOrEmpty(chaine))
            {
                return result;
            }
            else
            {
                if (!int.TryParse(str[0].ToString(), out parsedNumber)
                     || !int.TryParse(str[str.Length - 1].ToString(), out parsedNumber))
                {
                     return result;
                }
            }
            try
            {
                 result = str.Split(new char[] { '+' }).Select(s => Convert.ToInt32(s)).Sum();
            }
            finally
            {
                 return result;
            }
    }
