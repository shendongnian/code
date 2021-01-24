    protected override void RegisterTypes()
    {
       Container.Register(ctx => Xamarin.Forms.DependencyService.Get<ISavePicture>())
          .As<ISavePicture>();
    }
