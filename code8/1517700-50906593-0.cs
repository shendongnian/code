    class CustomControllerFeatureProvider : ControllerFeatureProvider
    {
        protected override bool IsController(TypeInfo typeInfo)
        {
            var isCustomController = !typeInfo.IsAbstract && typeof(MyCustomControllerBase).IsAssignableFrom(typeInfo);
            return isCustomController || base.IsController(typeInfo);
        }
    }
