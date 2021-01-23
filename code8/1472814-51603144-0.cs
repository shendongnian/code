    public partial class Home : TabbedPage
    {
        public Home()
        {
            var alphaPage = new NavigationPage(new ExistingAlphaPage());
            alphaPage .Title = "Alpha";
            var betaPage = new NavigationPage(new ExistingBetaPage());
            betaPage.Title = "Beta";
            var gamaPage = new NavigationPage(new ExistingGamaPage());
            gamaPage .Title = "Gama";
            Children.Add(alphaPage);
            Children.Add(betaPage);
            Children.Add(gamaPage);
        }
    }
