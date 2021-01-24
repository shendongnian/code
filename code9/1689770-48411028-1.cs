    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);
        Intent = intent;
    }
    protected override void OnPostResume()
    {
        base.OnPostResume();
        if (Intent.Extras != null)
        {
            string fileName = Intent.Extras.GetString("alarmIntent");
            if (!string.IsNullOrEmpty(fileName))
            {
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync (new myForm());
            }
            Intent.RemoveExtra("alarmIntent");
        }
    }
