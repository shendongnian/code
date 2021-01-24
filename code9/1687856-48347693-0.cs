    IFaceDetectionServiceFactory
    {
        FaceDetectionService Create(int devinceIndex);
    }
    kernel.AddFacility<TypedFactoryFacility>();
    kernel.Register(Component.For<IFaceDetectionServiceFactory>().AsFactory());
    kernel.Register(Component.For<FaceDetectionService>());
