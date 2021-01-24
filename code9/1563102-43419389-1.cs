    protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<DynamicImageView>(
                nameof(DynamicImageView.AnimatingColor),
                image => new DynamicImageViewAnimatingColorBinding (image));
            
            base.FillTargetFactories(registry);
        }
