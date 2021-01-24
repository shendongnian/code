    public ActionResult MyAction(int myParam)
    {
        try
        {
            if(ModelState.IsValid)
            {
                // do something useful
                return RedirectToAction("NextAction");
            }
            else{
           return RedirectToAction("Error", "Error");
            }
        }
        catch(Exception ex)
        {
            return RedirectToAction("Error", "Error");
        }
    }
