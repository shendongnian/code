     public ActionResult Search(string searchString)
        {
            
            ViewBag.SearchString = searchString; // This line send your string back to your view
            return View();
        }
