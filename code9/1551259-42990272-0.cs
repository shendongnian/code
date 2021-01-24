    //taken from https://github.com/xamarin/Xamarin.Social/blob/master/samples/Xamarin.Social.Sample.Android/MainActivity.cs 
    void Share (Service service, Button shareButton)
    {
        Item item = new Item {
    	    Text = "I'm sharing great things using Xamarin!",
     	    Links = new List<Uri> {
    	    new Uri ("http://xamarin.com"),
    	    },
        };
    
        Intent intent = service.GetShareUI (this, item, shareResult => {
    	    shareButton.Text = service.Title + " shared: " + shareResult;
    	});
    
    	StartActivity (intent);
    }
    public override void OnCreate(Bundle bundle)
    {
        ...
        facebookButton.Click += (sender, args) =>
		{
			try
			{
				Share (Facebook, facebookButton); 
			}
			catch (Exception ex)
			{
				ShowMessage("Facebook: " + ex.Message);
			}
		};
        ...
    }
