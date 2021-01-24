    interface IReadable
    {
        object GetValue();
    }
    interface IWritable
    {
        void SetValue(object value);
    }
    interface IReadableWritable : IReadable, IWritable
    {
        
    }
