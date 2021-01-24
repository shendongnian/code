        // this is what is returned from the service.
        // it has a List<IResponse> on it to hold  the resposnes
        MasterResposne resposne = new MasterResponse();
        List<ExecutionResult> tasks = new List<ExecutionResult>();
        List<ExecutionResult> executionResults = new List<ExecutionResult>();
        foreach(IRequest req in MasterRequest.Requests)
        {
            // factory to get the proper request processor
            RequestProcessor p  = rp.GetProcessor(req);
            ExecutionResult er = engine.GetResult(req);
            executionResults.Add(er);
            tasks.Add(er.Task);
         }
          await Task.WhenAll<IResponse>(tasks);
          foreach (ExecutionResult r in executionResults)
          {
              if (r.Task.IsCompleted)
              {
                  response.AddResponse(r.Task.Result);
              }
              else
              {
                  r.Response.Status = false;
                  AggregateException flat = r.Task.Exception.Flatten();
                  foreach (Exception e in flat.InnerExceptions)
                  {
                      Log.ErrorFormat("Reqest [{0}] threw [{1}]", r.Response.RequestId, e);
                      r.Response.StatusReason.AppendLine(e.Message);
                  }
              }
          }
