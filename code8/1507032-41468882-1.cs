        public ActionResult PickGroupForHomework(PickGroupForHomeworkViewModel model)
        {
            ClassDeclarationsDBEntities2 entities = new ClassDeclarationsDBEntities2();
            model.groups = entities.Groups.ToList();
            model.users = entities.Users.ToList();
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
            }
            else
            {
                RedirectToAction("PickGroupForHomework", "Account", new {subject_id = id, qty=model.qty });
            }
            return View(model);
        }
