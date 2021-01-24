    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
    {
                Window.DecorView.SystemUiVisibility = 0;
                var statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("_statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                statusBarHeightInfo.SetValue(this, 0);
                Window.SetStatusBarColor(new Android.Graphics.Color(18, 52, 86, 255));
    }
