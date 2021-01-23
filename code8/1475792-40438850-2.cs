    public class VehicleBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var typeValueProvider = bindingContext.ValueProvider.GetValue("Type");
            var type = (int)typeValueProvider.ConvertTo(typeof(int));
            Type instanceType = null;
            switch (type)
            {
                case 1:
                    instanceType = typeof(CarViewModel);
                    break;
                case 2:
                    instanceType = typeof(TankViewModel);
                    break;
            }
            if (!typeof(VehicleViewModel).IsAssignableFrom(instanceType))
            {
                throw new InvalidOperationException("Bad Type");
            }
            var model = Activator.CreateInstance(instanceType);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, instanceType);
            return model;
        }
    }
