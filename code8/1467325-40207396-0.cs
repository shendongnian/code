    [PSerializable]
    public class MyAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            // Code to execute before the target method ...
        }
    }
