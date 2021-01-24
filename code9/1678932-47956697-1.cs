    public class HttpDataContextStorageContainer<T> : IDataContextStorageContainer<T> where T : class {
        private const string DataContextKey = "DataContext";
        private readonly IHttpContextAccessor accessor;
        public HttpDataContextStorageContainer(IHttpContextAccessor accessor) {
            this.accessor = accessor;
        }
        public T GetDataContext() {
            var current = accessor.HttpContext;
            T objectContext = null;
            if (current.Items.ContainsKey(DataContextKey)) {
                objectContext = (T)current.Items[DataContextKey];
            }
            return objectContext;
        }
        public void Clear() {
            var current = accessor.HttpContext;
            if (current.Items.ContainsKey(DataContextKey)) {
                current.Items[DataContextKey] = null;
            }
        }
        public void Store(T objectContext) {
            var current = accessor.HttpContext;
            if (current.Items.ContainsKey(DataContextKey)) {
                current.Items[DataContextKey] = objectContext;
            } else {
                current.Items.Add(DataContextKey, objectContext);
            }
        }
    }
