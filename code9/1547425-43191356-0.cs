    public class CustomPageRenderer : PageRenderer
    {
        private NavigationPage _navigationPage;
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            _navigationPage = GetNavigationPage(Element);
            SubscribeToPopped(_navigationPage);
        }
        private void SubscribeToPopped(NavigationPage navigationPage)
        {
            if (navigationPage == null)
            {
                return;
            }
            navigationPage.Popped += OnPagePopped;
        }
        protected override void Dispose(bool disposing)
        {
            Log.Info("===========Dispose called===========");
            base.Dispose(disposing);
        }
        private void OnPagePopped(object sender, NavigationEventArgs args)
        {
            if (args.Page != Element)
            {
                return;
            }
            Dispose(true);
            _navigationPage.Popped -= OnPagePopped;
        }
        private static NavigationPage GetNavigationPage(Element element)
        {
            if (element == null)
            {
                return null;
            }
            while (true)
            {
                if (element.Parent == null || element.Parent.GetType() == typeof(NavigationPage))
                {
                    return element.Parent as NavigationPage;
                }
                element = element.Parent;
            }
        }
    }
