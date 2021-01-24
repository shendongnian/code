    private IMvxInteraction _interaction;
    public IMvxInteraction MyMvxInteraction
    {
        get => this._interaction;
        set
        {
            if (this._interaction != null)
                this._interaction.Requested -= this.OnInteractionRequested;
                
            this._interaction = value;
            this._interaction.Requested += this.OnInteractionRequested;
        }
    }
    private void OnInteractionRequested(object sender, EventArgs e)
    {
        var vm = this.DataContext as MyViewModel;
        if (vm.ClientID != "")
            posClient = new PosClient(this, vm.ClientID);
    }
