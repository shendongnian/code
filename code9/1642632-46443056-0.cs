    class Program
    {
        static void Main(string[] args)
        {
            var bytes = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");
            var totp = new Totp(bytes);
            var result = totp.ComputeTotp();
            var remainingTime = totp.RemainingSeconds();
        }
    }
