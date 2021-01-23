    public sealed class NotNullAttribute : LocationLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            var requiredConstruction = new ObjectConstruction( typeof( PostSharp.Patterns.Contracts.RequiredAttribute ) );
            yield return new AspectInstance( targetElement, requiredConstruction, null );
        }
    }
