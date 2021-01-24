    public readonly struct Nullable<T> where T : struct
    {
        private readonly bool hasValue; // Do not rename (binary serialization)
        internal readonly T value; // Do not rename (binary serialization)
        …
        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_NoValue);
                }
                return value;
            }
        }
    …
