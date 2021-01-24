    public class MyServiceFromMyLibrary : IMyServiceFromMyLibrary
    {
        private readonly INodeServices nodeServices;
        public MyServiceFromMyLibrary(INodeServices nodeServices)
        {
            this.nodeServices = nodeServices;
        }
        // ...
    }
