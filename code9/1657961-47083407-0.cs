       ImageHexAsString = "0xFFD8FFE000104A4649460001010100....";
            List<byte> byteList = new List<byte>();
            string hexPart = ImageHexAsString.Substring(2);
            for (int i = 0; i < hexPart.Length / 2; i++)
            {
                string hexNumber = hexPart.Substring(i * 2, 2);
                byteList.Add((byte)Convert.ToInt32(hexNumber, 16));
            }
            byte[] original = byteList.ToArray();
            Bitmap bitmap = BitmapFactory.DecodeByteArray(original, 0, original.Length);
            imageView.SetImageBitmap(bitmap);
