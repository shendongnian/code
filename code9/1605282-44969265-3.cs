        public static T Execute<T>(Func<T> func, TransactionExecutionOptions options = null) where T : IMyResponse
        {
            options = options ?? TransactionExecutionOptions.Default;
            T res;
            try
            {
                using (var tx = new TransactionScope(options))
                {
                    res = func();
                    tx.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                res.SetResponseServerError();
            }
            catch (ApplicationException ex)
            {
                res.SetResponseServerError();
            }
            return res;
        }
