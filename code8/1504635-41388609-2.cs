    class Mine<T> where T : struct, IEquatable<T>
    {
        T val;
        public T Value
        {
            set
            {
                if (val.Equals(value)) // 
                {
                    // .. do something ...
                }
            }
        }
    }
