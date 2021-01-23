    public class BuildTrackingExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Strategies.AddNew<BuildTrackingStrategy>(UnityBuildStage.TypeMapping);
        }
        public static IBuildTrackingPolicy GetPolicy(IBuilderContext context)
        {
            return context.Policies.Get<IBuildTrackingPolicy>(context.BuildKey, true);
        }
        public static IBuildTrackingPolicy SetPolicy(IBuilderContext context)
        {
            IBuildTrackingPolicy policy = new BuildTrackingPolicy();
            context.Policies.SetDefault(policy);
            return policy;
        }
    }
    public class BuildTrackingStrategy : BuilderStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            var policy = BuildTrackingExtension.GetPolicy(context)
                ?? BuildTrackingExtension.SetPolicy(context);
            policy.BuildKeys.Push(context.BuildKey);
        }
        public override void PostBuildUp(IBuilderContext context)
        {
            IBuildTrackingPolicy policy = BuildTrackingExtension.GetPolicy(context);
            if ((policy != null) && (policy.BuildKeys.Count > 0))
            {
                policy.BuildKeys.Pop();
            }
        }
    }
    public interface IBuildTrackingPolicy : IBuilderPolicy
    {
        Stack<object> BuildKeys { get; }
    }
    public class BuildTrackingPolicy : IBuildTrackingPolicy
    {
        public BuildTrackingPolicy()
        {
            BuildKeys = new Stack<object>();
        }
        public Stack<object> BuildKeys { get; private set; }
    }
