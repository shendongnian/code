    interface IReadableVar
    {
        object GetValue();
    }
    interface IWritableVar
    {
        void SetValue(object value);
    }
    interface IReadableWritableVar : IReadableVar, IWritableVar
    {
        
    }
