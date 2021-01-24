    class Program
    {
        static void Main(string[] args)
        {
            // https://blockchain.info/block-height/286819
            int version = 2;
            string previousBlock = "000000000000000117c80378b8da0e33559b5997f2ad55e2f7d18ec1975b9717";
            string merkelRoot = "871714dcbae6c8193a2bb9b2a69fe1c0440399f38d94b3a0f1b447275a29978a";
            int nonce = 856192328;
            long timestamp = new DateTimeOffset(DateTime.SpecifyKind(DateTime.Parse("2014-02-20 04:57:25"), DateTimeKind.Utc)).ToUnixTimeSeconds();
            int bits = 419520339;
            var header = new StringBuilder()
                .Append(ReverseAndSwap(version.ToString("D8")))
                .Append(ReverseAndSwap(previousBlock))
                .Append(ReverseAndSwap(merkelRoot))
                .Append(ReverseAndSwap(timestamp.ToString("x2")))
                .Append(ReverseAndSwap(bits.ToString("x2")))
                .Append(ReverseAndSwap(nonce.ToString("x2")))
                .ToString();
            
            Debug.Assert(string.CompareOrdinal(header, "0200000017975b97c18ed1f7e255adf297599b55330edab87803c81701000000000000008a97295a2747b4f1a0b3948df3990344c0e19fa6b2b92b3a19c8e6badc141787358b0553535f011948750833") == 0);
            var bytes = HexToBytes(header);
            SHA256 sha = new SHA256Managed();
            bytes = sha.ComputeHash(sha.ComputeHash(bytes)).Reverse().ToArray();
            var hash = BytesToHex(bytes);
            Debug.Assert(string.CompareOrdinal(hash, "0000000000000000e067a478024addfecdc93628978aa52d91fabd4292982a50") == 0);
        }
        private static string ReverseAndSwap(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (var i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i - (i % 2 == 0 ? -1 : 1)]);
            }
            
            return sb.ToString();
        }
        public static byte[] HexToBytes(string hex)
        {
            byte[] HexAsBytes = new byte[hex.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hex.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            return HexAsBytes;
        }
        public static string BytesToHex(byte[] bytes)
        {
            var output = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; ++i)
            {
                output.AppendFormat("{0:x2}", bytes[i]);
            }
            return output.ToString();
        }
        public static bool Verify(string header)
        {
            // We assume the bits that are going to be 0 are going to be between 10 and 99.
            int zbits = int.Parse(header.Substring(2, 2));
            int bytesToCheck = zbits / 8;
            int remainderBitsToCheck = zbits % 8;
            byte[] zArray = Enumerable.Repeat((byte)0x00, bytesToCheck).ToArray();
            byte remainderMask = (byte)(0xFF << (8 - remainderBitsToCheck));
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(header));
            return hash.Take(bytesToCheck).SequenceEqual(zArray) && ((hash[bytesToCheck] & remainderMask) == 0);
        }
    }
