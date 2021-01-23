    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    {
            var typeValueProvider = bindingContext.ValueProvider.GetValue("Type");
            var type = (int)typeValueProvider.ConvertTo(typeof(int));
            Type instanceType = null;
            switch (type)
            {
                case 1:
                    instanceType = typeof(PlanoPagamentoCartaoViewModel );
                    break;
                case 2:
                    instanceType = typeof(PlanoPagamentoCrediarioViewModel );
                    break;
            }
            if (!typeof(IPlanoPagamentosParcelas).IsAssignableFrom(instanceType))
            {
                throw new InvalidOperationException("Bad Type");
            }
            var model = Activator.CreateInstance(instanceType);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, instanceType);
            return model;
    }
