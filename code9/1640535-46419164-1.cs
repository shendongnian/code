    private void HandleAndroidException(object sender, RaiseThrowableEventArgs e)
    {
        Intent intent = new Intent(this, typeof(CrashDialog));
        intent.PutExtra("Error_Text", e.ToString());
        intent.SetFlags(ActivityFlags.NewTask);
        this.StartActivity(intent);
        Java.Lang.JavaSystem.Exit(0);// Close this app process
    }
