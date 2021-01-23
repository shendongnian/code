    public ActionResult _searchPartial()
        {
            List<tblProduct> getProduct = new List<tblProduct>();
            getProduct = db.tblProducts.ToList();
            if (getProduct != null)
            {
                return View("_searchPartial", getProduct);
            }
            else
            {
                return View("_searchPartial"); // return without passing model
            }
        }
