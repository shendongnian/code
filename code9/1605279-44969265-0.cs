        public static T Execute<T>(Func<T> func, TransactionExecutionOptions options = null)
        {
            options = options ?? TransactionExecutionOptions.Default;
            T res;
            using (var tx = new TransactionScope(options))
            {
                res = func();
                tx.Complete();
            }
            return res;
        }
