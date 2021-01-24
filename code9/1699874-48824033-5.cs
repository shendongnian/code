    public class Program
    {
        public static void Main(string[] args)
        {
            using (var writer =
                new StreamWriter(@"C:\Users\Farttoos\Desktop\Nasser_Last\Crypto(AES)_Stego(text)_Final\Crypto_Stego\Dictionary.txt"))
            {
                Console.SetOut(writer);
                Console.Write("Hello World!");
                Act();
            }
        }
    }
