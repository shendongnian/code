        [HttpPost]
        public ActionResult Search(SearchCriteria searchCriteria)
        {
            if (ModelState.IsValid)
            {
                var searchResults = _searchProvider.GetData(searchCriteria);
                return Json(new
                {
                    searchResults
                }, JsonRequestBehavior.AllowGet);
            }
            string errorMessages = string.Join(" <br /> ", this.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return this.Json(new { HasError = true, ErrorMessages = errorMessages });
        }
