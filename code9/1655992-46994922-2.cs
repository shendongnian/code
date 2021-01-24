    [HttpPost]
    public ActionResult ModidyProduct(Productdetail prodData)
    {
        try
        {
            //to do : Save  
        }
        catch (Exception ex)
        {
            //to do : Log the exception
            return Json(new { status = "error", message=ex.Message });
        }
        return Json(new { status="success"});
    }
