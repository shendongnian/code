    using System;
    using System.IO;
    using SharpCompress.Compressors;
    using SharpCompress.Compressors.Deflate;
    using System.Linq;
                        
    public class Program
    {
        public static void Main()
        {
            var dataBuffer = Enumerable.Range(1, 50000).Select(e => (byte)(e % 256)).ToArray();
            
            using (var dataStream = new MemoryStream(dataBuffer))
            {
                // Note: this refers to SharpCompress.Compressors.Deflate.DeflateStream                
                using (var deflateStream = new DeflateStream(dataStream, CompressionMode.Compress))
                {
                    ConsumeStream(deflateStream);
                }
            }
        }
        
        public static void ConsumeStream(Stream stream)
        {
            // Let's just prove we can reinflate to the original data...
            byte[] data;
            using (var decompressed = new MemoryStream())
            {
                using (var decompressor = new DeflateStream(stream, CompressionMode.Decompress))
                {
                    decompressor.CopyTo(decompressed);
                }
                data = decompressed.ToArray();
            }
            Console.WriteLine("Reinflated size: " + data.Length);
            int errors = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != (i + 1) % 256)
                {
                    errors++;
                }
            }
            Console.WriteLine("Total errors: " + errors);
        }
    }
