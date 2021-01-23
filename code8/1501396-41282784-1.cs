    public class CustomModelBinder : DefaultModelBinder {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType) {
        AbstractC1 data = MyFactory.createDerivedClass(...);
        return data;
    }
