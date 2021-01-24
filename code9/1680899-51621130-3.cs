        public static async Task<object> CastToObject<T>([NotNull] this Task<T> task)
        {
            return await task.ConfigureAwait(false);
        }
        public static async Task<TResult> Cast<TResult>([NotNull] this Task<object> task)
        {
            return (TResult) await task.ConfigureAwait(false);
        }
