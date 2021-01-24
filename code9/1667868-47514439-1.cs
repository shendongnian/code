    static byte[] Compress(string s, Encoding encoding) {
        // `compressed` will contain result of compression
        using (var compressed = new MemoryStream()) {
            // source is our original uncompressed data
            using (var source = new MemoryStream(encoding.GetBytes(s))) {
                // stream we are passing to GZipStream is that 
                // in which compressed data will be written
                using (var gzip = new GZipStream(compressed, CompressionMode.Compress)) {
                    // just write whole source into gzip stream with CopyTo
                    source.CopyTo(gzip);
                }
            }
            return compressed.ToArray();
        }
    }
    static string Decompress(Stream source, Encoding encoding) {
        // stream which we pass to GZipStream is that which contains
        // compressed data
        using (var gzip = new GZipStream(source, CompressionMode.Decompress)) {
            using (var decompressed = new MemoryStream()) {
                gzip.CopyTo(decompressed);
                return encoding.GetString(decompressed.ToArray());
            }
        }
    }
