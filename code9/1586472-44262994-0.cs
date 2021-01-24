    namespace binaryTranslate
    {
        class Program
        {
            static void Main(string[] args)
            {
                //convertBin("01001000 01100001 01101100 01101100 01101111 00100001");
                string results = BinaryTranslate.convertBin(new byte[] { 0x44, 0x61, 0x6c, 0x6c, 0x6f, 0x21 });
            }
        }
       public  class BinaryTranslate
        {
            public static string convertBin(byte[] CodeInput)
            {
                return string.Join("", CodeInput.Select(x => x.ToString("X2")));
            }
        }
    }
