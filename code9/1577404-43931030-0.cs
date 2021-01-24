    namespace OpenQA.Selenium
    {
        //
        // Summary:
        //     Defines an interface allowing the user to access the browser's history and to
        //     navigate to a given URL.
        public interface INavigation
        {
            //
            // Summary:
            //     Move back a single entry in the browser's history.
            void Back();
            //
            // Summary:
            //     Move a single "item" forward in the browser's history.
            //
            // Remarks:
            //     Does nothing if we are on the latest page viewed.
            void Forward();
            //
            // Summary:
            //     Load a new web page in the current browser window.
            //
            // Parameters:
            //   url:
            //     The URL to load. It is best to use a fully qualified URL
            //
            // Remarks:
            //     Calling the OpenQA.Selenium.INavigation.GoToUrl(System.String) method will load
            //     a new web page in the current browser window. This is done using an HTTP GET
            //     operation, and the method will block until the load is complete. This will follow
            //     redirects issued either by the server or as a meta-redirect from within the returned
            //     HTML. Should a meta-redirect "rest" for any duration of time, it is best to wait
            //     until this timeout is over, since should the underlying page change while your
            //     test is executing the results of future calls against this interface will be
            //     against the freshly loaded page.
            void GoToUrl(string url);
            void GoToUrl(Uri url);
            //
            // Summary:
            //     Refreshes the current page.
            void Refresh();
        }
    }
