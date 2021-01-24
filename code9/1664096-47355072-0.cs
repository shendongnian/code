    IBinder mBinder;
    [return: GeneratedEnum]
    public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
    {
        Toast.MakeText(this, "BroadcastService is running ", ToastLength.Long).Show();
		Xamarin.Forms.MessagingCenter.Send<App>((App)Xamarin.Forms.Application.Current, "dowork");
        base.OnStartCommand(intent, flags, startId);
        return StartCommandResult.Sticky;
    }
