    [AttributeUsage(AttributeTargets.Class)]
        public class Inpectable : ContextAttribute
        {
            public Inpectable() : base("Inspectable")
            {
            }
    
            public override void GetPropertiesForNewContext(IConstructionCallMessage ccm)
            {
                ccm.ContextProperties.Add(new InspectorProperty());
            }
        }
