    protected override void RegisterTypes()
    {
       var builder = new ContainerBuilder();
       builder.Register(ctx => Xamarin.Forms.DependencyService.Get<ISavePicture>())
          .As<ISavePicture>();
       builder.Update(Container);
    }
