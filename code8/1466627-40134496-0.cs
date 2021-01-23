    public class Program
    {
        public static void Main(string[] args)
        {
            var key = GenerateRandomNumber(32);
            var hexEncodedKey = BitConverter.ToString(key).Replace("-", "");
            Console.WriteLine(hexEncodedKey);
        }
        public static byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
    }
