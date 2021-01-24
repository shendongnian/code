    protected override void InitializeLastChance()
    {
            base.InitializeLastChance();
            Mvx.RegisterType<IToastService, ToastService>();
    }
