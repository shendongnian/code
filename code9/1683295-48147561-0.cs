    public class App : MvxApplication
    {
       public override void Initialize()
       {
          ...
          Mvx.ConstructAndRegisterSingleton<IDialogService,DialogService>();
          ...
       }
    }
