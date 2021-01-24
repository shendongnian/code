    protected override void OnCreate(Android.OS.Bundle bundle)
    {
        base.OnCreate(bundle);
        var set = this.CreateBindingSet<MenuView, MenuViewModel>();
        set.Bind(this).For(view => view.Interaction).To(viewModel => viewModel.Interaction).OneWay();
        set.Apply();
    }
