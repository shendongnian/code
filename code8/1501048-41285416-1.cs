    private static IControllerProcessor CreateSpecificControllerProcessor(
        IResolutionRoot resolutionRoot, string vendorName)
    {
        return resolutionRoot.Get<IControllerProcessor>(vendorName);
    }
    Bind<Func<IControllerProcessor>()
        .ToConstant(vendorName => CreateSpecficiControllerProcessor(this.Kernel, vendorName));
