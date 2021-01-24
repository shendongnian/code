        public static string HexStringFromArrayChangeEndian(byte[] data)
        {
            StringBuilder sdata = new StringBuilder();
            for (int s = data.Length - 1; s >= 0; s--)
                sdata.Append(string.Format("{0:X}", data[s]).PadLeft(2, '0'));
            return sdata.ToString();
        }
        public static string HexStringFromArraySameEndian(byte[] data)
        {
            StringBuilder sdata = new StringBuilder();
            for (int s = 0; s < data.Length; s++)
                sdata.Append(string.Format("{0:X}", data[s]).PadLeft(2, '0'));
            return sdata.ToString();
        }
