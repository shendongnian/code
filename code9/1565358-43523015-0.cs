     public override async Task OnInitializing()
     {
            await base.OnInitializing();
            await InitializeComponents();
            MyFilePicker.Set(x => x.AllowOnly(MediaSource.PickPhoto, 
           MediaSource.TakePhoto));
     }
