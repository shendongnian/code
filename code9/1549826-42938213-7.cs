    // developer supplies here with his/hers own array
    // or this library uses its own fast C++ wrapper with a [] overload
    public IReadOnlyList<T> array { get; set; }
    // returns float, int, byte
    public T this[int i]
    {
        get
        {
            return array[i]; // float[], int[], FloatArr, ...
        }
    }
