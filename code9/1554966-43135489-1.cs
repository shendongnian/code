     [HttpPost]
       public ActionResult WelcomeScreenPost(string Detail, string Greeting, int id)
        {
            Interview inter = new Interview
            {
                Greeting = Greeting,
                Detail = Detail,
                VacancyId = id,
            };
            db.Interview.Add(inter);
            db.SaveChanges();
            var urlBuilder = new UrlHelper(Request.RequestContext);
            var url = urlBuilder.Action("Index", "Questions", new { id = inter.Interview_Id });
            return Json(new { Result = "Success", Message = "Saved Successfully", RedirectUrl = url });
        }
