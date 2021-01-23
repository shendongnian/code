    public class Handler<T, SomeResponseType> : IAsyncRequestHandler<T, SomeResponseType> where T:IAsyncRequest<SomeResponseType>
    {
        public Task<SomeResponseType> Handle(T message)
        {
            throw new NotImplementedException();
        }
    }
