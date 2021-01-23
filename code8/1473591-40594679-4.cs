    protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
    {
        base.FillTargetFactories(registry);
        registry.RegisterCustomBindingFactory<EditText>("DecimalText", inputField => new DecimalEditTextTargetBinding(inputField));
    }
