    public abstract ItemControllerBase<T> : Controller
        where T : BaseItem
    {
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
    
            var viewModel = filterContext.Controller.ViewData.Model;
    
            var model = viewModel as IItemViewModel<T>;
            if (model == null)
            {
                return;
            }
    
            model.Item = itemService.GetCurrentItem();
        }
    }
