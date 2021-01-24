    public class MvcApplication : System.Web.HttpApplication
    {
        //[any methods]
        protected void Session_Start()
        {
            // 'using' will call entity.Dispose() at the end of the block so you
            // don't have to bother about disposing your entity
            using(OnlineStoreEntities entity = new OnlineStoreEntities()){
                // store your categories inside a Session variable as a List<Category>
                HttpContext.Current.Session["Categories"] = entity.Categories.ToList();
            }
        }
    }
