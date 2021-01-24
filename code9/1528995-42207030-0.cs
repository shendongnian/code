    class EFCommentInterceptor : IDbCommandInterceptor {
        private static readonly ThreadLocal<string> _comment = new ThreadLocal<string>();
        internal static void SetComment(string comment) {
            _comment.Value = comment;
        }
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
            AddComment(command);
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
            _comment.Value = null;
        }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) {
            AddComment(command);
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) {
            _comment.Value = null;
        }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
            AddComment(command);
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
            _comment.Value = null;
        }
        private void AddComment(DbCommand command) {
            if (!String.IsNullOrWhiteSpace(_comment.Value))
                command.CommandText += "\r\n\r\n-- " + _comment.Value;
        }
    }
