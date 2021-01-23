    static void Main(string[] args)
    {
        int count = 0;
        StringBuilder sb = new StringBuilder();
        Random random = new Random();
        while (count < 500000) {                
            int randomNumber = random.Next(100000000, 999999999);
            if (ValidateTFN(randomNumber.ToString()))
            {
                sb.AppendLine(randomNumber.ToString());
                count++;
            }
        }
        System.IO.File.WriteAllText("TFNs.txt", sb.ToString());
    }
    
    
    public static bool ValidateTFN(string tfn)
    {
        //validate only digits
        if (!IsNumeric(tfn)) return false;
    
        //validate length
        if (tfn.Length != 9) return false;
    
        int[] digits = Array.ConvertAll(tfn.ToArray(), c => (int)Char.GetNumericValue(c));
    
        //do the calcs
        var sum = (digits[0] * 1)
                + (digits[1] * 4)
                + (digits[2] * 3)
                + (digits[3] * 7)
                + (digits[4] * 5)
                + (digits[5] * 8)
                + (digits[6] * 6)
                + (digits[7] * 9)
                + (digits[8] * 10);
    
        var remainder = sum % 11;
        return (remainder == 0);
    }
    
    public static bool IsNumeric(string s)
    {
        float output;
        return float.TryParse(s, out output);
    }
