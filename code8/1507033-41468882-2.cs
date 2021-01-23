        public ActionResult PickGroupForHomework(int subject_id, int qty)
        {
            //Initialize your model here. Below is just an example.
            ClassDeclarationsDBEntities2 entities = new ClassDeclarationsDBEntities2();
            PickGroupForHomeworkViewModel model = new PickGroupForHomeworkViewModel();
            model.groups = entities.Groups.ToList();
            model.users = entities.Users.ToList();
            model.subject_id = subject_id;
            model.qty = qty;
            return View("PickGroupForHomework", model);
        }
        [HttpPost]
        public ActionResult PickGroupForHomework(PickGroupForHomeworkViewModel model)
        {
            ClassDeclarationsDBEntities2 entities = new ClassDeclarationsDBEntities2();
            int id = model.subject_id;
            var subj = entities.Subjects
                    .Where(b => b.class_id == model.subject_id)
                    .FirstOrDefault();
            if (subj != null)
            {
                model.subject_name = subj.name;
            }
            if (ModelState.IsValid)
            {
                //Save to database
                [code goes here]
                //return to a View to show your results
                return View("[Your view to see the results]")
            }
            
            //Model Validation did not pass
            //or exception occurred go back to View
            return View(model);
        }
