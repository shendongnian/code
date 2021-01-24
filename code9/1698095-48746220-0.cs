    public class ContainerContext<TModule> where TModule: IModule, new()
    {
        private IContainer _container;
        protected ContainerContext()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new TModule());
            // Because Autofac will resolve services using the last registration, we can change all our web api 
            // services to by InstancePerDependency instead of InstancePerRequest which is obviously better
            // when testing.
            builder.RegisterType<AnswerProvider>().As<IAnswerProvider>().InstancePerDependency();
            builder.RegisterType<AttributeProvider>().As<IAttributeProvider>().InstancePerDependency();
            builder.RegisterType<CategoryProvider>().As<ICategoryProvider>().InstancePerDependency();
            builder.RegisterType<ClaimProvider>().As<IClaimProvider>().InstancePerDependency();
            builder.RegisterType<ClientProvider>().As<IClientProvider>().InstancePerDependency();
            builder.RegisterType<CriteriaProvider>().As<ICriteriaProvider>().InstancePerDependency();
            builder.RegisterType<FeedProvider>().As<IFeedProvider>().InstancePerDependency();
            builder.RegisterType<FormulaProvider>().As<IFormulaProvider>().InstancePerDependency();
            builder.RegisterType<ImageProvider>().As<IImageProvider>().InstancePerDependency();
            builder.RegisterType<GroupProvider>().As<IGroupProvider>().InstancePerDependency();
            builder.RegisterType<QuestionProvider>().As<IQuestionProvider>().InstancePerDependency();
            builder.RegisterType<StripeProvider>().As<IStripeProvider>().InstancePerDependency();
            builder.RegisterType<ApiAiProvider>().As<IApiAiProvider>().InstancePerDependency();
            builder.RegisterType<PiiikProvider>().As<IPiiikProvider>().InstancePerDependency();
            builder.RegisterType<ProductProvider>().As<IProductProvider>().InstancePerDependency();
            builder.RegisterType<SettingProvider>().As<ISettingProvider>().InstancePerDependency();
            builder.RegisterType<TrackingProvider>().As<ITrackingProvider>().InstancePerDependency();
            _container = builder.Build();
        }
        protected TEntity Resolve<TEntity>() => _container.Resolve<TEntity>();
        protected void Dispose() => _container.Dispose();
    }
