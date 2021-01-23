     public abstract class ControllerTestBase<TController, TModel, TDbContext> where TController : BaseController<TModel, TDbContext>, new() 
                                                                               where TModel : class, ITableData
                                                                               where TDbContext: DbContext, new()
    {
        protected readonly TController Controller;
        protected ControllerTestBase()
        {   
            Controller = new TController();
            var context = new TDbContext();
            Controller.SetDomainManager(new EntityDomainManager<TModel>(context, new HttpRequestMessage()));
        }
    }
