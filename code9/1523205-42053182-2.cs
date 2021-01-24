            [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetProducts(string searchProduct, int? page, string perPage)
        {
            var product = int.Parse(searchProduct);
            
            var obj = await this.ShowReviewDetails(searchProduct, page, perPage) as IPagedList;
            return PartialView("ShowReviewDetails", obj);
        }
