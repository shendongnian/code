    using PostSharp.Aspects;
    using PostSharp.Serialization;
    [PSerializable]
    public class ValidationAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            // make you validation here
            validate();
        }
    }
