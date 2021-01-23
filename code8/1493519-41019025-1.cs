    public class LogCreationExtension : UnityContainerExtension
    {
        private ILogFactory LogFactory;
        private LogCreationStrategy strategy;
        public LogCreationExtension(ILogFactory logFactory)
        {
            LogFactory = logFactory;
        }
        protected override void Initialize()
        {
            strategy = new LogCreationStrategy(LogFactory);
            Context.Strategies.Add(strategy, UnityBuildStage.PreCreation);
        }
    }
    public class LogCreationStrategy : BuilderStrategy
    {
        public bool IsPolicySet { get; private set; }
        private ILogFactory LogFactory;
        public LogCreationStrategy(ILogFactory logFactory)
        {
            LogFactory = logFactory;
        }
        public override void PreBuildUp(IBuilderContext context)
        {
            Type typeToBuild = context.BuildKey.Type;
            if (typeof(ILog).Equals(typeToBuild))
            {
                if (context.Policies.Get<IBuildPlanPolicy>(context.BuildKey) == null)
                {
                    Type typeForLog = LogCreationStrategy.GetLogType(context);
                    IBuildPlanPolicy policy = new LogBuildPlanPolicy(typeForLog, LogFactory);
                    context.Policies.Set<IBuildPlanPolicy>(policy, context.BuildKey);
                    IsPolicySet = true;
                }
            }
        }
        public override void PostBuildUp(IBuilderContext context)
        {
            if (IsPolicySet)
            {
                context.Policies.Clear<IBuildPlanPolicy>(context.BuildKey);
                IsPolicySet = false;
            }
        }
        private static Type GetLogType(IBuilderContext context)
        {
            Type logType = null;
            IBuildTrackingPolicy buildTrackingPolicy = BuildTrackingExtension.GetPolicy(context);
            if ((buildTrackingPolicy != null) && (buildTrackingPolicy.BuildKeys.Count >= 2))
            {
                logType = ((NamedTypeBuildKey)buildTrackingPolicy.BuildKeys.ElementAt(1)).Type;
            }
            else
            {
                StackTrace stackTrace = new StackTrace();
                //first two are in the log creation strategy, can skip over them
                for (int i = 2; i < stackTrace.FrameCount; i++)
                {
                    StackFrame frame = stackTrace.GetFrame(i);
                    logType = frame.GetMethod().DeclaringType;
                    if (!logType.FullName.StartsWith("Microsoft.Practices"))
                    {
                        break;
                    }
                }
            }
            return logType;
        }
    }
    public class LogBuildPlanPolicy : IBuildPlanPolicy
    {
        private ILogFactory LogFactory;
        public LogBuildPlanPolicy(Type logType, ILogFactory logFactory)
        {
            LogType = logType;
            LogFactory = logFactory;
        }
        public Type LogType { get; private set; }
        public void BuildUp(IBuilderContext context)
        {
            if (context.Existing == null)
            {
                ILog log = LogFactory.Initialize(LogType);
                context.Existing = log;
            }
        }
    }
