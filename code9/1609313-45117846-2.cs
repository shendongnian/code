    public static class Extensions
    {    
        public static TRet NullSafeCall<TValue,TRet>( this TValue value, Func<TValue,TRet> func )
            where TValue : class
            where TRet : class
        {
            if( value != null ) return func( value );
            return null;
        }
    }
