    public static class ConsistentGuid
    {
        public static System.Guid Generate(object obj)
        {
            var bytes = new byte[16];
    
            var type = obj.GetType();
    
            var features = new object[]
            {
                type,
                obj
            };
    
            BitConverter.GetBytes(LongHash(features))
                .CopyTo(bytes, 0);
                
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            features = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
                features[i] = properties[i].GetValue(obj);
                
            BitConverter.GetBytes(LongHash(features))
                .CopyTo(bytes, 8);
    
            return new System.Guid(bytes);
        }
    
        public static int Hash(object[] features, uint seed = 2166136261)
        {
            // http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode/263416#263416
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)seed;
                for (int i = 0; i < features.Length; i++)
                {
                    if (features[i] == null) // Suitable nullity checks etc, of course :)
                        continue;
    
                    hash = (hash * 16777619) ^ features[i].GetHashCode();
                }
    
                return hash;
            }
        }
    
        private static long LongHash(object[] features, ulong seed = 2166136261)
        {
            // http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode/263416#263416
            unchecked // Overflow is fine, just wrap
            {
                long hash = (long)seed;
                for (int i = 0; i < features.Length; i++)
                {
                    if (features[i] == null) // Suitable nullity checks etc, of course :)
                        continue;
    
                    hash = (hash * 16777619) ^ features[i].GetHashCode();
                }
    
                return hash;
            }
        }
    }
