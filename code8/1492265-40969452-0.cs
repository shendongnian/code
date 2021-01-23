    public class PaginationModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if(modelType == typeof(PagingParamsVM))
            {
                var page = default(int?);
                var model = bindingContext.Model;
                var valueProvider = bindingContext.ValueProvider;
                var pageValue = valueProvider.GetValue("Page");
                var tmp = default(int);
                if(pageValue != null && int.TryParse(pageValue.AttemptedValue, out tmp))
                {
                    page = tmp;
                }
                var pageSize = default(int?);
                var sizeValue = valueProvider.GetValue("PageSize");
                if(sizeValue != null && int.TryParse(sizeValue.AttemptedValue, out tmp))
                {
                    pageSize = tmp;
                }
                return new PagingParamsVM { Page = page, PageSize = pageSize };
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
