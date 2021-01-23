       public static bool IsThisString(string strInput)
        {
            foreach (char c in strInput)
            {
                if (char.IsLetter(c))
                    return true;
            }
            return false;
        }
