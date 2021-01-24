        public static string UnzipString3(byte[] byteArrayCompressedContent)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var compressStream = new MemoryStream(byteArrayCompressedContent))
                {
                    using (var deflateStream = new DeflateStream(compressStream, CompressionMode.Decompress))
                    {
                        deflateStream.CopyTo(outputStream);
                    }
                }
                return Encoding.UTF8.GetString(outputStream.ToArray());
            }
        }
