     public ActionResult CreateNewChoice(int? id)
        {
            var questions_choices = new List<questions_choices>();
    
            for (int i = 0; i < 4; i++)
            {
                questions_choices.Add(new questions_choices(){questions_id = id});               
            }                 
            return View(questions_choices);
        }
