    public class MyCollection<T> : Collection<T>
    {
        [OnError]
        void OnError(StreamingContext context, ErrorContext errorContext)
        {
            if (errorContext.OriginalObject != this)
            {
                // Error occurred deserializing an item in the collection.  Swallow it.
                errorContext.Handled = true;
            }
        }
    }
