    public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
    {
        int nextPhase = -1;
        switch(args.Phase)
        {
            case 0:
                nextPhase = 1;
                this.SetDataRoot(args.Item);
                if (!removedDataContextHandler)
                {
                    removedDataContextHandler = true;
                    ((global::Windows.UI.Xaml.Controls.StackPanel)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                }
                this.initialized = true;
                break;
            case 1:
                global::Windows.UI.Xaml.Markup.XamlBindingHelper.ResumeRendering(this.obj4);
                nextPhase = -1;
                break;
        }
        this.Update_((global::System.String) args.Item, 1 << (int)args.Phase);
        return nextPhase;
    }
    public void ResetTemplate()
    {
        this.bindingsTracking.ReleaseAllListeners();
        global::Windows.UI.Xaml.Markup.XamlBindingHelper.SuspendRendering(this.obj4);
    }
