    [ModelBinder(BinderType = typeof(CustomerOrdersEntityBinder))]
    public class CustomerOrdersModelView
    {
        public string CustomerID { get; set; }
        public int FY { get; set; }
        public float? item1_price { get; set; }
        public float? item2_price { get; set; }   
        public float? item9_price { get; set; }
    }
    public class CustomerOrdersEntityBinder : IModelBinder
    {
      
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var model = new CustomerOrdersModelView();
            if (bindingContext.ModelType != typeof(CustomerOrdersModelView))
                return TaskCache.CompletedTask;
            // Try to fetch the value of the argument by name
            var valueProviderResult =  bindingContext.ValueProvider.GetValue("item1_price");
            if (valueProviderResult == ValueProviderResult.None)
            {
                return TaskCache.CompletedTask;
            }
            model.item1_price = float.Parse(valueProviderResult.FirstValue.Replace("$",string.Empty).Replace(",",string.Empty));
            
            bindingContext.Result = ModelBindingResult.Success(model);
            return TaskCache.CompletedTask;
        }
    }
