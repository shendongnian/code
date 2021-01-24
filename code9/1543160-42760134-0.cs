    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Approve (int id, History history)
    {
        // Some pseudo-logic here:
        switch(roles)
        {
            case Manager:
            case User:
            {
               return View("ManagerUser");
            }
            case Manager:
            case Analyst:
            {
               return View("ManagerAnalyst");
            }
        }
    }
