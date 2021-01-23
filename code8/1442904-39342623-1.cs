    public ActionResult UpdateQuantities(Models.ViewModels.CartViewModel cartModel)
    {
        // instantiate your database context if it's not already done
        using (var db = new Context())
        {
            for (int i = 0; i < cartModel.CartArray.Length; i++)
            {
                // update your records one at a time
                db.YourItems.Where(i => <your_criteria>).Member = NewValue;
            }
            // commit your changes only once at the end
            db.SaveChanges();
            return View();
        }
