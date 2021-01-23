    public abstract class BaseItem
    {
        public String Type { get; set; }
    }
    public class DerivedItem1 : BaseItem
    {
        public DerivedItem1()
        {
            Type = "DerivedItem1";
        }
    }
    public class DerivedItem2 : BaseItem
    {
        public DerivedItem2()
        {
            Type = "DerivedItem2";
        }
    }
    public class MyActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewModel = filterContext.Controller.ViewData.Model;
            var model = viewModel as IItemViewModel<BaseItem>;
            // model is always null :(
            if (model == null)
            {
                return;
            }
            model.Item = new DerivedItem2(); // Set the Item property here;
        }
    }
