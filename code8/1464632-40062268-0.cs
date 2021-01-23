    public static class Extensions
    {
        public static byte[] Prepend(this byte[] that, params byte[] data)
        {
            byte[] modified;
            modified = new byte[that.Length + data.Length];
            Array.Copy(data, modified, data.Length);
            Array.Copy(that, 0, modified, data.Length, that.Length);
            return modified;
        }
        public static byte[] Append(this byte[] that, params byte[] data)
        {
            byte[] modified;
            modified = new byte[that.Length + data.Length];
            Array.Copy(that, modified, that.Length);
            Array.Copy(data, 0, modified, that.Length, data.Length);
            return modified;
        }
    }
