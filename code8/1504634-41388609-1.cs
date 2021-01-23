    class Mine<T> where T : struct, IEquatable<T>
    {
        T val;
        public T Value
        {
            set
            {
                if (object.Equals(val, value)) // 
                {
                    // .. do something ...
                }
            }
        }
    }
