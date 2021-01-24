    public IActionResult Results (string searchType, string searchTerm)
        {
            //look up search results via JobData class   
            //if user searches 'all'
            if (searchType == "all")
            {
                ViewBag.Jobs = JobData.FindByValue(searchTerm);
            }
            //if user searches by category
            else
            {
                ViewBag.Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            //pass them into Views/Search/index.cshtml 
            return View("~/Views/SearchController/Index.cshtml");
        }
