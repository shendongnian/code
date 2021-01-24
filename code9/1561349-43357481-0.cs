        //boilerplate, off in your extension method library
        public static TOut OrDefault<TIn, TOut>(this TIn input, 
            Func<TIn, TOut> possiblyNullFunc)
        {
            try { return possiblyNullFunc(input); }
            catch (NullReferenceException) //for most reference types
            { return default(TOut); }
            catch (InvalidOperationException) //for Nullable<T>
            { return default(TOut); }
        }
        ...
        //usage
        if (Object1.OrDefault(o=>o.Object2.Object3.Object4) != null)
        {
            ...
        }
