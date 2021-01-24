    class Program
    {
        private static byte[] data = new byte[8]
        {
            // header
            0,
            0,
            // status
            1,
            
            // message size
            8,
            0,
            0,
            0,
            // data
            1
        };
        static byte[] Read(Stream stream)
        {
            const int headerLength = 7;
            const int sizePosition = 3;
            var buffer =  new byte[headerLength];
            stream.Read(buffer, 0, headerLength);
            // for BitConverter to work
            // the order of bytes in the array must 
            // reflect the endianness of the computer system's architecture
            var size = BitConverter.ToUInt32(buffer, sizePosition);
            var result = new byte[size];
            Array.Copy(buffer, result, headerLength);
            stream.Read(result, headerLength, (int)size - headerLength);
            return result;
        }
        static void Main(string[] args)
        {
            var stream = new MemoryStream(data);
            byte[] bytes = Read(stream);
            foreach (var b in bytes)
            {
                Console.WriteLine(b);
            }
        }
    }
