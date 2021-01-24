        public ActionResult CreateNewChoice(int? id)
        {
        var questions_choices = new List<questions_choices>();
        questions_choices Objquestion;
        for (int i = 0; i < 4; i++)
        {
            Objquestion = new questions_choices();
            Objquestion.questions_id = id;
            questions_choices.Add(Objquestion);               
        }                 
        return View(questions_choices);
        }
