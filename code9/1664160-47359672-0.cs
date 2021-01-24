    namespace Util
    {
        public static class BondTypeAliasConverter
        {
            public decimal Convert(ArraySegment<byte> blob, decimal unused) { ... }
            public ArraySegment<byte> Convert(decimal d, ArraySegment<byte> unused) { ... }
        }
    }
    
    namespace First
    {
        public static class BondTypeAliasConverter
        {
            public decimal Convert(ArraySegment<byte> blob, decimal unused)
            {
                return Util.BondTypeAliasConverter.Convert(blob, unused);
            }
    
            ....
        }
    }
    
    namespace First.Second
    {
        public static class BondTypeAliasConverter
        {
            public decimal Convert(ArraySegment<byte> blob, decimal unused)
            {
                return Util.BondTypeAliasConverter.Convert(blob, unused);
            }
    
            ....
        }
    }
