     public class ReadAsyncResult<T>
    {
        public ReadAsyncResult()
        {
        }
        public ReadAsyncResult(T result)
        {
            Result = result;
            IsSuccess = result != null;
        }
        public T Result { get; set; }
        public bool IsSuccess { get; set; }
        public static async Task<ReadAsyncResult<T>> TryReadAsAsync<T>(HttpContent content)
        {
            return await TryReadAsAsync<T>(content, CancellationToken.None);
        }
        public static async Task<ReadAsyncResult<T>> TryReadAsAsync<T>(HttpContent content,
            CancellationToken cancellationToken)
        {
            if (content == null)
                return new ReadAsyncResult<T>();
            var type = typeof(T);
            var objectContent = content as ObjectContent;
            if (objectContent?.Value != null && type.IsInstanceOfType(objectContent.Value))
            {
                return new ReadAsyncResult<T>((T) objectContent.Value);
            }
            var mediaType = content.Headers.ContentType;
            var reader =
                new MediaTypeFormatterCollection(new MediaTypeFormatterCollection()).FindReader(type, mediaType);
            if (reader == null) return new ReadAsyncResult<T>();
            var value = await ReadAsAsyncCore<T>(content, type, reader, cancellationToken);
            return new ReadAsyncResult<T>(value);
        }
        private static async Task<T> ReadAsAsyncCore<T>(HttpContent content, Type type, MediaTypeFormatter formatter,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = await content.ReadAsStreamAsync();
            var result = await formatter.ReadFromStreamAsync(type, stream, content, null, cancellationToken);
            return (T) result;
        }
    }
