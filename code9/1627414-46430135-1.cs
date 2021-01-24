    //Have all of your pages inherit this page
    public abstract class BasePage : ContentPage
	{
		public BasePage () : base()
		{
		}
        
        public override void OnAppearing()
        {
            protected override void OnAppearing()
            {
                base.OnAppearing();
                //Mainly for Android, restore the current page to the last saved page when the app paused
                if( PageService.SavedStatePage != null )
                {
                    PageService.CurrentPage = PageService.SavedStatePage;
                    PageService.SavedStatePage = null;
                }
                else
                {
                    //default behavior. Set the current page to the one currently appearing.
                    PageService.CurrentPage = this;
                }
            }
        }
    }
