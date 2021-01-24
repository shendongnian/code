    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddToBasket(MultipleModelInOneView model)
    {
        Basket basket = Basket.GetBasket();
        basket.AddToBasket(model.Product.ID, model.Product.quantity);
        return RedirectToAction("Index");
    }
