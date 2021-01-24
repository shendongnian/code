        public static class DictionaryExtension
        {
            public static VType GetSafeValue<KType, VType>(this Dictionary<KType, VType> dic, KType key) where VType : class
            {
                VType v;
                if (!dic.TryGetValue(key, out v))
                {
                    return null;
                }
                return v;
            }
        }
