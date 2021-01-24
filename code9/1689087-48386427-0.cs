    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Collections.Generic.Stack`1"/> class that is empty and has the default initial capacity.
    /// </summary>
    [__DynamicallyInvokable]
    public Stack()
    {
      this._array = Stack<T>._emptyArray;
      this._size = 0;
      this._version = 0;
    }
    private static T[] _emptyArray = new T[0];
