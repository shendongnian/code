    [HttpPost]
        public ActionResult Formulaire(Commentaire com)
        {
               
            context.Liste.Add(com);
            context.SaveChanges();
    
            return View(context);
    
        }
