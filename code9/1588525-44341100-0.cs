    public static class HashingExtensions
    {
        public static bool Compare(this object v1, object v2)
        {
            var w1 = v1.ToBinary(); var w2 = v2.ToBinary();
            if (w1.Count() == w2.Count())
            {
                for (int x = 0; x < w1.Count(); x++)
                {
                    if (w1[x] != w2[x])
                    {
                        return false;
                    }
                }
                return true;
            }
            else {
                return false;
            }
        }
        public static Byte[] ToBinary(this object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }
    }
