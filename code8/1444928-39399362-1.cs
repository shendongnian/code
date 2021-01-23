    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
          Bind<IRepository>.To<SQLBlogRepository>();
         }
    }
