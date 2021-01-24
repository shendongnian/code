    public Task BindModelAsync(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }
        bindingContext.ValueProvider = new FormValueProvider(controllerContext);
        ActivityModel model = (ActivityModel)bindingContext.Model ?? new ActivityModel();
        model.content = bindingContext.ValueProvider.GetValue("Content")
    
        return TaskCache.CompletedTask;
    }
