    public static class RabbitMqPasswordHelper
    {
        public static string EncodePassword(string password)
        {
            using (RandomNumberGenerator rand = RandomNumberGenerator.Create())
            using (var sha512 = SHA512.Create())
            {
                byte[] salt = new byte[4];
                rand.GetBytes(salt);
                byte[] saltedPassword = MergeByteArray(salt, Encoding.UTF8.GetBytes(password));
                byte[] saltedPasswordHash = sha512.ComputeHash(saltedPassword);
                return Convert.ToBase64String(MergeByteArray(salt, saltedPasswordHash));
            }
        }
        private static byte[] MergeByteArray(byte[] array1, byte[] array2)
        {
            byte[] merge = new byte[array1.Length + array2.Length];
            array1.CopyTo(merge, 0);
            array2.CopyTo(merge, array1.Length);
            return merge;
        }
    }
