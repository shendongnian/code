    protected override IAsyncResult OnBeginGetToken(string appliesTo, string action,
        TimeSpan timeout, AsyncCallback callback, object state)
    {
      return ApmAsyncFactory.ToBegin(GetCustomTokenAsync(appliesTo), callback, state);
    }
    protected override SecurityToken OnEndGetToken(IAsyncResult result,
        out DateTime cacheUntil)
    {
      var ret = ApmAsyncFactory.ToEnd<SharedAccessSignatureToken>(result);
      cacheUntil = ...;
      return ret;
    }
