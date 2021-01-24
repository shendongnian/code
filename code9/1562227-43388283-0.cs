    class Program
    {
        private static byte[] convertHex(string value)
        {
            string[] hexVal = value.Split(' ');
            byte[] output = new byte[hexVal.Length];
            var i = 0;
            foreach (string hex in hexVal)
            {
                byte val = (byte)(Convert.ToInt32(hex, 16));
                output[i++] = val;
            }
            return output;
        }
        static void Main(string[] args)
        {
            string MyString = "17 c7 df ef 85 3a dc dd b2 c4 b7 1d d8 d0 b3 e3 36 36 36 36 36";
            var file = new FileStream("file2.bin", FileMode.Create);
            var byteArray = convertHex(MyString);
            file.Write(byteArray, 0, byteArray.Length);
        }
    }
