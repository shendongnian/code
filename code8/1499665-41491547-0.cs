    [assembly:MyAspectProvider(
        AttributeTargetAssemblies = "System.Data", 
        AttributeTargetTypes = "System.Data.Common.DbCommand", 
        AttributeTargetMembers = "Execute*"
    )]
    [PSerializable]
    public class MyAspectProvider : MethodLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            yield return new AspectInstance(targetElement, new MyAspect());
        }
    }
    [PSerializable]
    public class MyAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            // ...
        }
    }
