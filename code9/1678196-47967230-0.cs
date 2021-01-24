    WebOperationContext webCtx;
    webCtx = WebOperationContext.Current;
    IncomingWebRequestContext incomingCtx;
    incomingCtx = webCtx.IncomingRequest;
    string uri;
    uri = incomingCtx.UriTemplateMatch.RequestUri.ToString();
    NameValueCollection query;
    query = incomingCtx.UriTemplateMatch.QueryParameters;
    string queryName;
    if (query.Count != 0)
    {
          var enumQ = query.GetEnumerator();
          while (enumQ.MoveNext())
          {
                queryName = enumQ.Current.ToString();
                Console.Writeline{"{0} = {1}", queryName, query[queryName]);
          }
    }
