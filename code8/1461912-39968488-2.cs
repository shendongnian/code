        public static String randomString()
        {
            String chars = "QWERTYUIOPASDFGHJKLZXCVBNM";
            Random rand = new Random();
            String finalstring = null;
            for (int i = 0; i < 8; i++)
            {
                finalstring += chars[GenerateRandomNumber(8)];
            }
            return finalstring;
        }
        public static int GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                return randomNumberGenerator.GetNextInt32(length);
            }
        }
