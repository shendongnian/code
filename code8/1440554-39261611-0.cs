    public class DefaultModelBindingHelperAdaptor : IModelBindingHelperAdaptor {
        public virtual Task<bool> TryUpdateModelAsync<TModel>(ControllerBase controller, TModel model) where TModel : class {
            return controller.TryUpdateModelAsync(model);
        }
    }
