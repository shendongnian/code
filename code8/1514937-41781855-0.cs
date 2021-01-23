        public abstract class BaseController<TModel, TDbContext> : TableController<TModel> where TModel : class, ITableData
                                                                                           where TDbContext:DbContext, new()
        {
            protected override void Initialize(HttpControllerContext controllerContext)
            {
                base.Initialize(controllerContext);
                var context = new TDbContext();
                SetDomainManager(new EntityDomainManager<TModel>(context, Request));
            }
    
            public void SetDomainManager(EntityDomainManager<TModel> domainManager)
            {
                DomainManager = domainManager;
            }
        }
