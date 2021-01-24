    public class NgNavigation : INavigation
    {
        private NgWebDriver ngDriver;
        private INavigation navigation;
        // irrelevant constructors and such
        /// <summary>
        /// Load a new web page in the current browser window.
        /// </summary>
        /// <param name="url">The URL to load. It is best to use a fully qualified URL</param>
        /// <param name="ensureAngularApp">Ensure the page is an Angular page by throwing an exception.</param>
        public void GoToUrl(string url, bool ensureAngularApp)
        {
            if (ensureAngularApp)
            {
                this.ngDriver.Url = url;
            }
            else
            {
                this.navigation.GoToUrl(url);
            }
        }
