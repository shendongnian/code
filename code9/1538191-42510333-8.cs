    static class ErrorHandler {
        public static ExecuteWithErrorHandling<T>(Func<T> createObject, Action<Exception> exceptionHandler, Action<T> operation) where T : IDisposable
            T disposable = createObject();
            try {
                operation(disposable);
            }
            catch (Exception exc) {
                exceptionHandler(exc);
            }
            finally {
                disposable.Dispose();
            }
        }
    }
