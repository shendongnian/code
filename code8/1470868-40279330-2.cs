    public static string ProcessValidImport(int number)
    {
        List<string> output = new List<string>();
        int n = number;
        while (number > 0)
        {
            
            if (number % 10 == 7)
            {
               output.Add("SEVEN");
            }
            if (number % 10 == 9)
            {
                output.Add("NINE");
            }
            number = number / 10;
        }
        output.Reverse();
        return (output == null  || output.Count == 0 ) ? n.ToString() : string.Join("", output.ToArray());
    }
