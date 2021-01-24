    public class TestModelBinder : IModelBinder
    {
        private BodyModelBinder defaultBinder;
        public TestModelBinder(IList<IInputFormatter> formatters, IHttpRequestStreamReaderFactory readerFactory) // : base(formatters, readerFactory)
        {
            defaultBinder = new BodyModelBinder(formatters, readerFactory);
        }
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // callinng the default body binder
            await defaultBinder.BindModelAsync(bindingContext);
            if (bindingContext.Result.IsModelSet)
            {
                var data = bindingContext.Result.Model as TestModel;
                if (data != null)
                {
                    var value = bindingContext.ValueProvider.GetValue("Id").FirstValue;
                    int intValue = 0;
                    if (int.TryParse(value, out intValue))
                    {
                        // Override the Id property
                        data.Id = intValue;
                    }
                    value = bindingContext.ValueProvider.GetValue("RootId").FirstValue;
                    if (int.TryParse(value, out intValue))
                    {
                        // Override the RootId property
                        data.RootId = intValue;
                    }
                    bindingContext.Result = ModelBindingResult.Success(data);
                }
            }
        }
    }
