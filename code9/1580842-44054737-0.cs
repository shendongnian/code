      public ActionResult ActionName()
            {
                var list= query.ToList();
               decimal totBalance = 10.0M;   
               ViewBag.Banance= totBalance ;          
                return View(list);
            }
