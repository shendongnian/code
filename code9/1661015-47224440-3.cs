    public bool TrySetValue(T oldValue, T newValue)
    {
        object objectValue = RuntimeHelpers.GetObjectValue(this._value);
        Console.Write(object.ReferenceEquals(RuntimeHelpers.GetObjectValue(objectValue), RuntimeHelpers.GetObjectValue(this._value)));
        if (!object.Equals(Conversions.ToGenericParameter<T>(objectValue), oldValue))
        {
            return false;
        }
        object obj3 = newValue;
        return object.ReferenceEquals(RuntimeHelpers.GetObjectValue(Interlocked.CompareExchange(ref this._value, RuntimeHelpers.GetObjectValue(obj3), RuntimeHelpers.GetObjectValue(objectValue))), RuntimeHelpers.GetObjectValue(objectValue));
    }
