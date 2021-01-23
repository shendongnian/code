    [PSerializable]
    public class MyAspect : OnMethodBoundaryAspect, IInstanceScopedAspect
    {
        [ImportMember("QueryProcessor", IsRequired = true)] 
        public Property<IQueryProcessor> QueryProcessor;
        public override void OnEntry(MethodExecutionArgs args)
        {
            this.QueryProcessor.Get().ExecuteWithCache(/* ... */);
        }
        object IInstanceScopedAspect.CreateInstance(AdviceArgs adviceArgs)
        {
            return this.MemberwiseClone();
        }
        void IInstanceScopedAspect.RuntimeInitializeInstance()
        {
        }
    }
