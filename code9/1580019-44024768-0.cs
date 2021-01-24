    public ActionResult YourPageName(string NextAction)
    {
      if(NextAction == "next")
      {
       Session["position"] = (int)Session["position"] + 1;
      }
      elseif(NextAction == "prev")
      {
       Session["position"] = (int)Session["position"] - 1;
      }
      else
      {
       Session["position"] = 0;
      }
      return View();
    }
