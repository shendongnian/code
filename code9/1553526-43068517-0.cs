        [HttpGet, ActionName("Index")]
        public ActionResult WebpageGenerator(string id)
        {
            StringBuilder pageText = GetHTMLFromDB(id);
            string linkName = GetLink(pageText) //should now contain <a href="page1.html">
            string newLink = Url.Action("Index", "WebpageGenerator", new { id=linkName.OnlyPageName()});
            pageText.Replace(linkName, newLink);
            ViewBag.PageData = pageText.ToString();
            return View();
        }
