    public class Setup : MvxWindowsSetup
    {
       protected override void InitializeFirstChance()
       {
           Mvx.ConstructAndRegisterSingleton<IDialogService,DialogService>();
           base.InitializeFirstChance();
       }
    }
