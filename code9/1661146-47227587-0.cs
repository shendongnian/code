    [__DynamicallyInvokable]
    protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      if (request == null)
        throw new ArgumentNullException(nameof (request), SR.net_http_handler_norequest);
      this.CheckDisposed();
      if (Logging.On)
        Logging.Enter(Logging.Http, (object) this, nameof (SendAsync), (object) request);
      this.SetOperationStarted();
      TaskCompletionSource<HttpResponseMessage> completionSource = new TaskCompletionSource<HttpResponseMessage>();
      HttpClientHandler.RequestState state = new HttpClientHandler.RequestState();
      state.tcs = completionSource;
      state.cancellationToken = cancellationToken;
      state.requestMessage = request;
      try
      {
        HttpWebRequest prepareWebRequest = this.CreateAndPrepareWebRequest(request);
        state.webRequest = prepareWebRequest;
        cancellationToken.Register(HttpClientHandler.onCancel, (object) prepareWebRequest);
        if (ExecutionContext.IsFlowSuppressed())
        {
          IWebProxy webProxy = (IWebProxy) null;
          if (this.useProxy)
            webProxy = this.proxy ?? WebRequest.DefaultWebProxy;
          if (this.UseDefaultCredentials || this.Credentials != null || webProxy != null && webProxy.Credentials != null)
            this.SafeCaptureIdenity(state);
        }
        Task.Factory.StartNew(this.startRequest, (object) state);
      }
      catch (Exception ex)
      {
        this.HandleAsyncException(state, ex);
      }
      if (Logging.On)
        Logging.Exit(Logging.Http, (object) this, nameof (SendAsync), (object) completionSource.Task);
      return completionSource.Task;
    }
