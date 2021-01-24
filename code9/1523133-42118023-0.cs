    public class NgWebDriver : IWebDriver, IWrapsDriver, IJavaScriptExecutor
    {
        private const string AngularDeferBootstrap = "NG_DEFER_BOOTSTRAP!";
        private IWebDriver driver;
        private IJavaScriptExecutor jsExecutor;
        private string rootElement;
        private IList<NgModule> mockModules;
        // constructors and stuff
        /// <summary>
        /// Gets or sets the URL the browser is currently displaying.
        /// </summary>
        public string Url
        {
            get
            {
                this.WaitForAngular();
                return this.driver.Url;
            }
            set
            {
                // Reset URL
                this.driver.Url = "about:blank";
                // TODO: test Android
                IHasCapabilities hcDriver = this.driver as IHasCapabilities;
                if (hcDriver != null &&
                    (hcDriver.Capabilities.BrowserName == "internet explorer" ||
                     hcDriver.Capabilities.BrowserName == "MicrosoftEdge" ||
                     hcDriver.Capabilities.BrowserName == "phantomjs" ||
                     hcDriver.Capabilities.BrowserName == "firefox" ||
                     hcDriver.Capabilities.BrowserName.ToLower() == "safari"))
                {
                    this.ExecuteScript("window.name += '" + AngularDeferBootstrap + "';");
                    this.driver.Url = value;
                }
                else
                {
                    this.ExecuteScript("window.name += '" + AngularDeferBootstrap + "'; window.location.href = '" + value + "';");
                }
                if (!this.IgnoreSynchronization)
                {
                    try
                    {
                        // Make sure the page is an Angular page.
                        long? angularVersion = this.ExecuteAsyncScript(ClientSideScripts.TestForAngular) as long?;
                        if (angularVersion.HasValue)
                        {
                            if (angularVersion.Value == 1)
                            {
                                // At this point, Angular will pause for us, until angular.resumeBootstrap is called.
                                // Add default module for Angular v1
                                this.mockModules.Add(new Ng1BaseModule());
                                // Register extra modules
                                foreach (NgModule ngModule in this.mockModules)
                                {
                                    this.ExecuteScript(ngModule.Script);
                                }
                                // Resume Angular bootstrap
                                this.ExecuteScript(ClientSideScripts.ResumeAngularBootstrap,
                                    String.Join(",", this.mockModules.Select(m => m.Name).ToArray()));
                            }
                            else if (angularVersion.Value == 2)
                            {
                                if (this.mockModules.Count > 0)
                                {
                                    throw new NotSupportedException("Mock modules are not supported in Angular 2");
                                }
                            }
                        }
                    }
                    catch (WebDriverTimeoutException wdte)
                    {
                        throw new InvalidOperationException(
                            String.Format("Angular could not be found on the page '{0}'", value), wdte);
                    }
                }
            }
        }
