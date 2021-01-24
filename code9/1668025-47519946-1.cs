    public static decimal getDecimalFixed(decimal amount, decimal subtract)
    {
        var parts = amount.ToString().Split('.');
        decimal sum = amount - subtract;
        // get's a string of zeros using the same amount of digits
        string part1zeros = new String('0', parts[0].Length); 
        string part2zeros = new String('0', parts[1].Length);
        // decimal format ex: ToString("000.0000")
        sum = Convert.ToDecimal(sum.ToString(part1zeros + "." + part2zeros));
    } 
            
