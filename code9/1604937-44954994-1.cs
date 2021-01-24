    static void Main(string[] args)
    {
        int number = 30;
        BigInteger fact;
        factorial(number, out  fact);        
    }
    public static void factorial(int events, out BigInteger eventfact)
    {
        eventfact = new BigInteger(1);
        for (int tt = 2; tt <= events; tt++)
        {
            eventfact = eventfact * tt;
        }
    }
