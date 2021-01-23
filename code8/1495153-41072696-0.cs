    public class MyModelBinder : DefaultModelBinder
    {
        private readonly Func<IRepository> repositoryProvider;
    
        public MyModelBinder(Func<IRepository> repositoryProvider)
        {
            this.repositoryProvider = repositoryProvider;
        }
    
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var id = ... //get id from http request.
            var list = (List<Entity>)Session["Entities"];
            var entity = list?.SingleOrDefault(x => x.Id == id);
            if (null == entity)
            {
                IRepository repository = this.repositoryProvider();
                entity = repository.GetEntity(id);
                //set entity in session
            }
            return entity; 
        }
    }
