 lang-cs
        private sealed class MongoCollectionEnumerator : IEnumerator<T> {
            private IMongoCollection<T> _collection;
            private IAsyncCursor<T> _cursor; // outer enumerator
            private IEnumerator<T> _currentBatchEnumerator; // inner enumerator
            public MongoCollectionEnumerator(IMongoCollection<T> collection) {
                _collection = collection;
                InternalInit();
            }
            #region interface implementation
            T IEnumerator<T>.Current {
                get {
                    return _currentBatchEnumerator.Current;
                }
            }
            object IEnumerator.Current {
                get {
                    return ThisAsTypedIEnumerator.Current;
                }
            }
            bool IEnumerator.MoveNext() {
                if (_currentBatchEnumerator != null) {
                    if (_currentBatchEnumerator.MoveNext()) {
                        return true;
                    }
                }
                // inner not initialized or already at end
                if (_cursor.MoveNext()) {
                    // advance the outer and defer back to the inner by recursing
                    _currentBatchEnumerator = _cursor.Current.GetEnumerator();
                    return ThisAsIEnumerator.MoveNext();
                }
                else { // outer cannot advance, this is the end
                    return false;
                }
            }
            void IEnumerator.Reset() {
                InternalCleanUp();
                InternalInit();
            }
            #endregion
            #region methods private
            // helper properties to retrieve an explicit interface-casted this
            private IEnumerator ThisAsIEnumerator => this;
            private IEnumerator<T> ThisAsTypedIEnumerator => this;
            private void InternalInit() {
                var filterBuilder = new FilterDefinitionBuilder<T>();
                _cursor = _collection.Find(filterBuilder.Empty).ToCursor();
            }
            private void InternalCleanUp() {
                if (_currentBatchEnumerator != null) {
                    _currentBatchEnumerator.Reset();
                    _currentBatchEnumerator = null;
                }
                if (_cursor != null) {
                    _cursor.Dispose();
                    _cursor = null;
                }
            }
            #endregion
            #region IDisposable implementation
            private bool disposedValue = false; // To detect redundant calls
            private void InternalDispose(bool disposing) {
                if (!disposedValue) {
                    if (disposing) {
                        InternalCleanUp();
                        _collection = null;
                    }
                    disposedValue = true;
                }
            }
            void IDisposable.Dispose() {
                InternalDispose(true);
            }
            #endregion
        }
