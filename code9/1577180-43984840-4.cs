    private static void HandleException(Exception ex) {
        TransactionScope scope = null;
        if (Transaction.Current != null)
            scope = new TransactionScope(TransactionScopeOption.Suppress);
        try {
            // do stuff
        }
        finally {
            scope?.Dispose();
        }
    }
