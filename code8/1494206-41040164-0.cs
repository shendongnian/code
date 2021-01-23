    public static class Extensions
    {
        public static byte[] GetBytes(this string @this, System.Text.Encoding encoding = null)
        {
            return (encoding??Encoding.UTF8).GetBytes(@this);
        }
        public static string GetString(this byte[] @this, System.Text.Encoding encoding = null)
        {
            return (encoding??Encoding.UTF8).GetString(@this);
        }
    }
