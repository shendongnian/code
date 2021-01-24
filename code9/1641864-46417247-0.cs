        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ...
            bindingContext.ModelState.SetModelValue("PageNo", new ValueProviderResult(pageNo.ToString()));
            bindingContext.ModelState.SetModelValue("CountOfItemsPerPage", new ValueProviderResult(length.ToString()));
            ModelStateEntry v;
            foreach (PropertyInfo pi in bindingContext.ModelType.GetProperties())
            {
                if (bindingContext.ModelState.TryGetValue(pi.Name, out v))
                {
                    try
                    {
                        pi.SetValue(model, v.RawValue);
                    }
                    catch
                    {
                    }
                }
            }
            bindingContext.Model = model;
            ...
        }
