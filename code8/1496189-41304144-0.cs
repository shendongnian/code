    [PSerializable]
    public class MyAspect : OnMethodBoundaryAspect
    {
        [Import]
        public IQueryProcessor QueryProcessor { get; set; }
        public override void RuntimeInitialize(MethodBase method)
        {
            ServiceInjector.BuildObject(this);
        }
    }
