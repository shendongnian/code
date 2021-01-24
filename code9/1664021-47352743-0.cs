    using System;
    using System.Text;
        
    public class Test
    {
        static void Main()
        {
            var bytes = new byte[] { 0x61, 0x62, 0xc4, 0x85, 0xc4, 0x87, 0x01, 0x02, 0x03 };
            var decoder = Encoding.UTF8.GetDecoder();
            var chars = new char[4];
            decoder.Convert(bytes, 0, bytes.Length, chars, 0, chars.Length,
                true, out int bytesUsed, out int charsUsed, out bool completed);
            Console.WriteLine($"Completed: {completed}");
            Console.WriteLine($"Bytes used: {bytesUsed}");
            Console.WriteLine($"Chars used: {charsUsed}");
            Console.WriteLine($"Text: {new string(chars, 0, charsUsed)}");
        }
    }
        
