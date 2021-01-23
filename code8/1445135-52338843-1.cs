            // POST: Dashboard (Index)
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Index(string excel)
            {
                string selectedTraining, selectedTrainingType;
                selectedTraining = Request["selectedTraining"];
                selectedTrainingType = Request["selectedTrainingType"];
