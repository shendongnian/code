    public ActionResult Display()
    {
        DisplayModel model = new DisplayModel
        {
             str = sb.ToString()
        }
        return View(model)
    }
