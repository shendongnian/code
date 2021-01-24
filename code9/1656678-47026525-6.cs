    [HttpGet]
    public ActionResult EditScore(int id)
    {
       Term1Score score = db.Term1Scores.FirstOrDefault(x => x.Id== id);
       if(score==null)
       {
          return Content(" This item does not exist"); // or a view with the message
       }
       return View(score);
    }
