    public class MyFilterAttribute : TypeFilterAttribute
    {
        public MyFilterAttribute():base(typeof(MyFilterImpl))
        {
        }
    
        private class MyFilterImpl : IAsyncActionFilter
        {
            public MyFilterImpl( *inject dependencies here*)
            {}
        }
    }
