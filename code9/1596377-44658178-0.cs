    public static class Base64
    {
        public static string EncodeBase64(string text)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }
        public static string EncodeBase64(byte[] array)
        {
            return System.Convert.ToBase64String(array);
        }
        public static string DecodeBase64ToString(string base64String)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64String));
        }
        public static Byte[] DecodeBase64ToBinary(string base64String)
        {
            Byte[] bytes = System.Convert.FromBase64String(base64String);
            return bytes;
        }
    }
