    public TModel BindModelFromGet<TBinder, TModel>(string modelName, string queryString, TBinder binder)
        where TBinder : IModelBinder
    {
        var httpControllerContext = new HttpControllerContext();
        httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, MOCK_URL + queryString);
        var bindingContext = new ModelBindingContext();
        var dataProvider = new DataAnnotationsModelMetadataProvider();
        var modelMetadata = dataProvider.GetMetadataForType(null, typeof(TModel));
        var httpActionContext = new HttpActionContext();
        httpActionContext.ControllerContext = httpControllerContext;
        var provider = new QueryStringValueProvider(httpActionContext, CultureInfo.InvariantCulture);
        bindingContext.ModelMetadata = modelMetadata;
        bindingContext.ValueProvider = provider;
        bindingContext.ModelName = modelName;
        if (binder.BindModel(httpActionContext, bindingContext))
        {
            return (TModel)bindingContext.Model;
        }
        throw new Exception("Model was not bindable");
    }
