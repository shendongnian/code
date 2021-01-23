    public static string ProcessValidImport(int number)
    {
        StringBuilder output = new StringBuilder();
        int n = number;
        while (number > 0)
        {
            
            if (number % 10 == 7)
            {
                output.Append("S");
            }
            if (number % 10 == 9)
            {
                output.Append("N");
            }
            number = number / 10;
        }
        return (output == null  || output.Length == 0 ) ? n.ToString() : Reverse(output.ToString());
    }
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
