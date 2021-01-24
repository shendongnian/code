    public class BodyAndRouteModelBinder : IModelBinder
    {
        private readonly IModelBinder _bodyBinder;
        private readonly IModelBinder _complexBinder;
        public BodyAndRouteModelBinder(IModelBinder bodyBinder, IModelBinder complexBinder)
        {
            _bodyBinder = bodyBinder;
            _complexBinder = complexBinder;
        }
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            await _bodyBinder.BindModelAsync(bindingContext);
            if (bindingContext.Result.IsModelSet)
            {
                bindingContext.Model = bindingContext.Result.Model;
            }
            await _complexBinder.BindModelAsync(bindingContext);
        }
    }
----------
    public class BodyAndRouteModelBinderProvider : IModelBinderProvider
    {
        private BodyModelBinderProvider _bodyModelBinderProvider;
        private ComplexTypeModelBinderProvider _complexTypeModelBinderProvider;
        public BodyAndRouteModelBinderProvider(BodyModelBinderProvider bodyModelBinderProvider, ComplexTypeModelBinderProvider complexTypeModelBinderProvider)
        {
            _bodyModelBinderProvider = bodyModelBinderProvider;
            _complexTypeModelBinderProvider = complexTypeModelBinderProvider;
        }
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var bodyBinder = _bodyModelBinderProvider.GetBinder(context);
            var complexBinder = _complexTypeModelBinderProvider.GetBinder(context);
            if (context.BindingInfo.BindingSource != null
                && context.BindingInfo.BindingSource.CanAcceptDataFrom(BodyAndRouteBindingSource.BodyAndRoute))
            {
                return new BodyAndRouteModelBinder(bodyBinder, complexBinder);
            }
            else
            {
                return null;
            }
        }
    }
