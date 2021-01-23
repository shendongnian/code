    public static int GenerateOTP(int digits)
        {
            if (digits < 3)
                return new Random().Next(10, 99);
            else
                return new Random().Next(MultiplyNTimes(digits), MultiplyNTimes(digits + 1) - 1);
        }
    private static int MultiplyNTimes(int n)
        {
            if (n == 1)
                return 1;
            else
                return 10 * MultiplyNTimes(n - 1);
        }
