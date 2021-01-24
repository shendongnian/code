    public interface IRenderingContext {
        string GetDataSource();
    }
    //...
    using Sitecore.Mvc.Presentation;
    public class RenderingContextWrapper : IRenderingContext {
        public string GetDataSource(){
            return RenderingContext.CurrentOrNull.Rendering.DataSource;
        }
    }
