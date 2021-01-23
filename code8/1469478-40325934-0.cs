        //http://ayende.com/blog/1583/i-hate-this-code
        private static IDbTransaction GetTransaction(ISession session)
        {
            using (var command = session.Connection.CreateCommand())
            {
                session.Transaction.Enlist(command);
                return command.Transaction;
            }
        }
