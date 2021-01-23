        [RedirectAfterActionFilter]
        public ActionResult DoSomethingAndGetRedirected()
        {
            // Save, Edit or Whatever
            //...
            return new EmptyResult(); // no need to return since the user will be redirected by the filter
        }
