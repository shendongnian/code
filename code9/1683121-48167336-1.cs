    public class Tab
    {
        private readonly string WindowIdentity;
        private readonly IWebDriver driver; //If you have a driver static class that can be accessed from anywhere,
        // then call the driver directly in the functions below, otherwise, initialize this variable in the constructor.
        /// <summary>
        /// Default constructor for Tab class, initializes the identity string from driver.
        /// </summary>
        /// <param name="windowIdentity">The unique string from running driver.</param>
        public Tab(string windowIdentity)
        {
            WindowIdentity = windowIdentity;
        }
        /// <summary>
        /// Runs the given script to the tab.
        /// </summary>
        /// <param name="script">The script to run.</param>
        public void RunScript(string script)
        {
            //Temporary variable to switch back to.
            string initialWindow = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(WindowIdentity);
            (IJavaScriptExecutor)driver.ExecuteScript(script);
            driver.SwitchTo().Window(initialWindow);
        }
    }
