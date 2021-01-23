    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        var viewModel = filterContext.Controller.ViewData.Model;
        var model = viewModel as IItemViewModel<BaseItem>;
        if (viewModel.GetType() == typeof(ItemViewModel<DerivedItem1>))
        {
            ((ItemViewModel<DerivedItem1>)viewModel).Item = new DerivedItem1();
        }
        else if (viewModel.GetType() == typeof(ItemViewModel<DerivedItem2>))
        {
            ((ItemViewModel<DerivedItem2>)viewModel).Item = new DerivedItem2();
        }
        else
        {
            throw new InvalidCastException("Unsupported cast from type: " + viewModel.GetType().FullName);
        }
    }
