    namespace Foo.Services.Impl.RestAPI
    {
        public class RestApiFooService : IFooService
        {
            private readonly IRestApi _restapi;
            public RestApiFooService( IRestApi restapi )
            { 
                _restapi = restapi;
            }
    
            public Task<Foo> GetByIdAsync( int id );
            {
                return await _restapi.FooEndpoint.GetAsync( id );
            }
        }
    }
