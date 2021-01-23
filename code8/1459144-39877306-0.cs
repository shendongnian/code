    public IAsyncResult BeginExecuteReader(CommandBehavior behavior)
    {
      if (caller != null)
        Throw(new MySqlException(Resources.UnableToStartSecondAsyncOp));
      caller = new AsyncDelegate(AsyncExecuteWrapper);
      asyncResult = caller.BeginInvoke(1, behavior, null, null);
      return asyncResult;
    }
