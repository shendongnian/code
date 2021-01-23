    public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count,
        AsyncCallback callback, object state)
    {
      var task = WriteAsync(buffer, offset, count);
      return ApmAsyncFactory.ToBegin(task, callback, state);
    }
    public override void EndWrite(IAsyncResult asyncResult)
    {
      ApmAsyncFactory.ToEnd(asyncResult);
    }
