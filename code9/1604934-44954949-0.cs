    static void Main(string[] args)
    {
        {
            int number = 30;
            long fact;
            factorial(number, out  fact);
        }
    }
    public static void factorial(int events, out  BigInteger eventfact)
    {
        eventfact = 1;
        for (int tt = 1; tt <= events; tt++)
        {
            eventfact = BigInteger.Multiply(eventfact, tt); }
    }
