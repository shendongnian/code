        static void Main(string[] args)
        {
            var s = "your long hex string";
            if (s.StartsWith("0x"))
                s = s.Remove(0, 2);
            using (var stream = new MemoryStream(ConvertHexStringToByteArray(s)))
            {
                var image = new Bitmap(stream);
                image.Save(DownloadPath, ImageFormat.Png);
            }            
        }
        public static byte[] ConvertHexStringToByteArray(string hexString) {
            if (hexString.Length%2 != 0) {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }
            byte[] HexAsBytes = new byte[hexString.Length/2];
            for (int index = 0; index < HexAsBytes.Length; index++) {
                string byteValue = hexString.Substring(index*2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            return HexAsBytes;
        }
