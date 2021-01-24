    public class Request
    {
        public int Parameter { get; }
        public Request(int parameter)
        {
             Parameter = parameter;
        }
        public TaskCompletionSource<IHttpActionResult> Result { get; } = new TaskCompletionSource<IHttpActionResult>();
    }
    public class Handler
    {
        public Subject<Request> ExampleObservable { get; } = new Subject<Request>();
        [Route("{id}")]
        [AcceptVerbs("GET")]
        public async Task<IHttpActionResult> example(int id)
        {
            var req = new Request(id);
            ExampleObservable.OnNext(req);
            return await req.Result.Task;
        }
    }
