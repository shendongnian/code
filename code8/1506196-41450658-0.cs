    public class Program
    {
        private static readonly byte[] XorBytes = {
            0x86, 0xFB, 0xEC, 0x37, 0x5D, 0x44, 0x9C, 0xFA, 0xC6,
            0x5E, 0x28, 0xE6, 0x13, 0xB6, 0x8A, 0x60, 0x54, 0x94
        };
        public static void Main(string[] args)
        {
            var filePath = args[0];
            var fileBytes = new byte[256];
            using (var fileReader = File.OpenRead(filePath))
            {
                fileReader.Read(fileBytes, 0, fileBytes.Length);
            }
            var passwordBytes = XorBytes
                .Select((x, i) => (byte) (fileBytes[i + 0x42] ^ x))
                .TakeWhile(x => x != 0);
            var password = Encoding.ASCII.GetString(passwordBytes.ToArray());
            Console.WriteLine($"Password is \"{password}\"");
            Console.ReadKey();
        }
    }
