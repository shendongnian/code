    public ActionResult ReturnPage(){
    
      using(var _context = new YourDbObject())
      {
         var listOfAgents = _context.Agents.OrderBy(x => x.FullName).ToList();
      }
      return View(listOfAgents);
    }
