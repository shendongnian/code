    public static BigInteger Fact(long input)
    {
        var result = new BigInteger(input);
        while (--input > 0)
        {
            result *= input;
        }
        return result;
    }
