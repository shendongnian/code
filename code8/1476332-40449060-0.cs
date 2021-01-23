    private static int GetRandom(int min, max) {
    using(System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                 byte[] randomNumber = new byte[4];
                 rng.GetBytes(randomNumber);
                 int value = BitConverter.ToInt32(randomNumber,0);
                 return Math.Abs(value%max+min);
            }
    }
