        public class CompositionRoot
        {
            public CompositionRoot(IRegistrator r)
            {
                r.Unregister<ILoggerFactory>();
                r.Register<ILoggerFactory, LoggerFactory>(Reuse.Singleton);
            }
        }
