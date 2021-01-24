    public sealed class OneTimeAssignable<T> where T : class
    {
        public T Value
        {
            get
            {
                return mValue;
            }
            set
            {
                if( mValue != null ) throw new InvalidOperationException( "Value can only be assigned once." );
                mValue = value;
            }
        }
        private T mValue;
    }
