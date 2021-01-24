    // this is what is returned from the service.
    // it has a List<IResponse> on it to hold  the resposnes
    MasterResposne resposne = new MasterResponse();
    List<ExecutionResult> tasks = new List<ExecutionResult>();
    foreach(IRequest req in MasterRequest.Requests)
    {
        // factory to get the proper request processor
        RequestProcessor p  = rp.GetProcessor(req);
        tasks.add(p.GetResult(req));
     }
     Parallel.ForEach(tasks, t =>
        {
             t.task.Wait();
              response.Responses.Add(t.Result);
         }
