     interface Field<T>
        {
            T Value { get; }
        }
    public class MyField<T> : Field<T>
        {
            private T _value;
            public T Value
            {
                get
                {
                    return _value;
                }
            }
        }
