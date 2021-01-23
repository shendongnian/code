     public ActionResult DetailEquipe()
     {
        Tuple<Model1, Model2> tuple = new Tuple<Model1, Model2>(new Model1(), new Model2());
        return View(tuple);
     }
