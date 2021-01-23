     [HttpGet]
        public ActionResult ListItems()
        {
            SiteStore site = new SiteStore();
            site.GetSites();
            IEnumerable<SiteViewModel> sites =
                site.SitesList.Select(s => new SiteViewModel
                {
                    Id = s.Id,
                    Type = s.Type
                });
          
            return PartialView("_ListItems", sites);
        }
