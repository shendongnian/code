    private async void Button2_Click (object sender, EventArgs e)
    {
        var previous = Button2.Background.ColorFilter;
    	if (answer == "ב")
    	{
            Button2.Background.SetColorFilter (Android.Graphics.Color.Green, Android.Graphics.PorterDuff.Mode.Multiply);
    	}
    	else
    	{
    		Button2.Background.SetColorFilter (Android.Graphics.Color.Red, Android.Graphics.PorterDuff.Mode.Multiply);
    	}
        // This will await 2 seconds before setting the original color.
        await Task.Delay (2000);
       // Using this so we are sure it will run in the UI thread.
        RunOnUiThread (() => {
            Button2.Background.SetColorFilter (previous);
            });
    }
