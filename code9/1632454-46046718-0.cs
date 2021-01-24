    var activityItemsNSUrl = NSUrl.FromString("http://stackoverflow.com");
    var activityItemsString = new NSString("StackOverflow");
    var activityItems = new NSObject[] { activityItemsString, activityItemsNSUrl };
    var activityViewController = new UIActivityViewController(activityItems, null)
    {
        ExcludedActivityTypes = new NSString[] {
            UIActivityType.PostToVimeo,
            new NSString("com.linkedin.LinkedIn.ShareExtension"),
            UIActivityType.PostToFlickr
        }
    };
    PresentViewController(activityViewController, true, () => { });
